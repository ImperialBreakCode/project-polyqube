'use client';

import * as React from 'react';
import { CropIcon, UploadIcon, XIcon } from 'lucide-react';
import { Button } from '@repo/ui/components/ui/Button';
import {
	FileUpload,
	FileUploadDropzone,
	FileUploadItem,
	FileUploadItemDelete,
	FileUploadItemMetadata,
	FileUploadItemPreview,
	FileUploadList,
	FileUploadTrigger,
} from '@repo/ui/components/ui/FileUpload';
import { AppButton } from '@/shared/elements/AppButton';
import CropProfilePictureDialog from '@/shared/elements/CropProfilePictureDialog';

interface SetProfilePictureProps {
	onSelectedImageChange: (image?: File) => void;
	onError: (message: string) => void;
}

const SelectProfilePicture = ({
	onSelectedImageChange,
	onError,
}: SetProfilePictureProps) => {
	const [files, setFiles] = React.useState<File[]>([]);
	const [selectedFile, setSelectedFile] = React.useState<File | null>(null);
	const [showCropDialog, setShowCropDialog] = React.useState(false);
	const [isFirstCrop, setIsFirstCrop] = React.useState(true);

	const selectedImageUrl = React.useMemo(() => {
		if (!selectedFile) return null;
		return URL.createObjectURL(selectedFile);
	}, [selectedFile]);

	React.useEffect(() => {
		return () => {
			if (selectedImageUrl) {
				URL.revokeObjectURL(selectedImageUrl);
			}
		};
	}, [selectedImageUrl]);

	const onFilesChange = React.useCallback((newFiles: File[]) => {
		setFiles(newFiles);
		if (newFiles.length > 0) {
			setSelectedFile(newFiles[0]!);
			setShowCropDialog(true);
		}
	}, []);

	const onFileCropSelect = React.useCallback((file: File) => {
		setSelectedFile(file);
		setShowCropDialog(true);
	}, []);

	const onFileCrop = React.useCallback(
		(file: File) => {
			if (isFirstCrop) {
				setIsFirstCrop(false);
			}

			onSelectedImageChange(file);
		},
		[isFirstCrop, onSelectedImageChange],
	);

	return (
		<>
			<CropProfilePictureDialog
				showCropDialog={showCropDialog}
				onCropDialogOpenChange={setShowCropDialog}
				selectedFileName={selectedFile?.name}
				selectedImageUrl={selectedImageUrl}
				onCrop={onFileCrop}
				canClose={!isFirstCrop}
			/>
			<FileUpload
				value={files}
				onValueChange={onFilesChange}
				accept='image/png,image/jpeg'
				maxFiles={1}
				maxSize={10 * 1024 * 1024}
				onFileReject={(_, message) => onError(message)}
				multiple
				className='w-full'
			>
				{files.length === 0 ? (
					<FileUploadDropzone className='min-h-32'>
						<div
							className='flex flex-col items-center gap-2
								text-center'
						>
							<UploadIcon className='size-8 text-muted-foreground' />
							<div>
								<p className='font-medium text-sm'>
									Drop images here or click to upload
								</p>
								<p className='text-muted-foreground text-xs'>
									PNG, JPG, WebP up to 10MB
								</p>
							</div>
							<FileUploadTrigger asChild>
								<AppButton className='p-2 h-9 mt-5'>
									Choose Image
								</AppButton>
							</FileUploadTrigger>
						</div>
					</FileUploadDropzone>
				) : (
					<></>
				)}

				<FileUploadList className='max-h-96 overflow-y-auto'>
					{files.map((file) => {
						return (
							<FileUploadItem key={file.name} value={file}>
								<FileUploadItemPreview
									render={(originalFile, fallback) => {
										if (file.type.startsWith('image/')) {
											const url =
												URL.createObjectURL(file);
											return (
												// biome-ignore lint/performance/noImgElement: dynamic cropped file URLs from user uploads don't work well with Next.js Image optimization
												// eslint-disable-next-line @next/next/no-img-element
												<img
													src={url}
													alt={originalFile.name}
													className='size-full
														object-cover'
												/>
											);
										}

										return fallback();
									}}
								/>
								<FileUploadItemMetadata />
								<div className='flex gap-1'>
									<Button
										variant='ghost'
										size='icon'
										className='size-8'
										onClick={() => onFileCropSelect(file)}
									>
										<CropIcon />
									</Button>
									<FileUploadItemDelete asChild>
										<Button
											variant='ghost'
											size='icon'
											className='size-8
												hover:bg-destructive/30
												hover:text-destructive-foreground
												dark:hover:bg-destructive
												dark:hover:text-destructive-foreground'
											onClick={() => {
												setIsFirstCrop(true);
												onSelectedImageChange(
													undefined,
												);
											}}
										>
											<XIcon />
										</Button>
									</FileUploadItemDelete>
								</div>
							</FileUploadItem>
						);
					})}
				</FileUploadList>
			</FileUpload>
		</>
	);
};

export default SelectProfilePicture;
