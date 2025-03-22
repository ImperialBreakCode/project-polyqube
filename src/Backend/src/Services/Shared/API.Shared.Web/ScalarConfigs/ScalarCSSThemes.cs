namespace API.Shared.Web.ScalarConfigs
{
    public static class ScalarCSSThemes
    {
        public const string CustomTheme = """
.light-mode {
    --scalar-color-1: #121212;
    --scalar-color-2: rgba(0, 0, 0, 0.6);
    --scalar-color-3: rgba(0, 0, 0, 0.4);
    --scalar-color-accent: #0a85d1;
    --scalar-background-1: #fff;
    --scalar-background-2: #f6f5f4;
    --scalar-background-3: #f1ede9;
    --scalar-background-accent: #5369d20f;
    --scalar-border-color: rgba(0, 0, 0, 0.08);
  }
  .dark-mode {
    --scalar-color-1: rgba(255, 255, 255, 0.81);
    --scalar-color-2: rgba(255, 255, 255, 0.443);
    --scalar-color-3: rgba(255, 255, 255, 0.282);
    --scalar-color-accent: #8ab4f8;
    --scalar-background-1: #202020;
    --scalar-background-2: #272727;
    --scalar-background-3: #333333;
    --scalar-background-accent: #8ab4f81f;
  }
""";
    }
}
