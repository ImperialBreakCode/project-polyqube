using API.Chats.Application.Features.Ollama.Client;
using API.Chats.Application.Features.Ollama.Models;
using API.Chats.Common.Features.ChatAgents.Constants;
using API.Chats.Common.Features.Chats.Exceptions;
using API.Chats.Common.Features.Participant.Exceptions;
using API.Chats.Domain;
using API.Shared.Application.Interfaces;

namespace API.Chats.Application.Features.Ollama.Commands.GenerateOllamaAgentReply
{
    internal class GenerateOllamaAgentReplyCommandHandler
        : ICommandHandler<GenerateOllamaAgentReplyCommand, GenerateOllamaAgentReplyResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOllamaChatClient _ollamaChatClient;

        public GenerateOllamaAgentReplyCommandHandler(
            IUnitOfWork unitOfWork,
            IOllamaChatClient ollamaChatClient)
        {
            _unitOfWork = unitOfWork;
            _ollamaChatClient = ollamaChatClient;
        }

        public async Task<GenerateOllamaAgentReplyResult> Handle(
            GenerateOllamaAgentReplyCommand request,
            CancellationToken cancellationToken)
        {
            if (request.ConversationMessages.Count == 0)
            {
                throw new InvalidOperationException("Conversation must include at least one user message.");
            }

            var chat = _unitOfWork.ChatRepository.GetById(request.ChatId);
            if (chat is null)
            {
                throw new ChatNotFoundException();
            }

            if (!chat.AIEnabled)
            {
                throw new ChatFunctionalityNotEnabled();
            }

            var agent = await _unitOfWork.ChatAgentRepository.GetByUsername(AIMemberConstants.AGENT_USERNAME);
            if (agent is null)
            {
                throw new InvalidOperationException($"Chat agent '{AIMemberConstants.AGENT_USERNAME}' is not seeded.");
            }

            var agentParticipant = await _unitOfWork.ParticipantRepository
                .GetChatParticipantByChatAgentId(agent.Id, request.ChatId);
            if (agentParticipant is null)
            {
                throw new ParticipantNotFoundException();
            }

            var ollamaMessages = new List<OllamaConversationMessage>
            {
                new(
                    "system",
                    $"You are {AIMemberConstants.AGENT_NAME}. Respond in character; keep replies concise unless the user asks for detail."),
            };
            ollamaMessages.AddRange(request.ConversationMessages);

            var reply = await _ollamaChatClient.CompleteChatAsync(ollamaMessages, cancellationToken);
            if (string.IsNullOrWhiteSpace(reply))
            {
                throw new InvalidOperationException("The model returned an empty reply.");
            }

            return new GenerateOllamaAgentReplyResult(reply.Trim(), agent.Id);
        }
    }
}
