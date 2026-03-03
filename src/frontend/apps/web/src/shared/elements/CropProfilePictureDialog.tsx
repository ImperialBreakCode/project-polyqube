'use client';

import React, { useEffect } from 'react';
import { toast } from 'sonner';
import {
	Dialog,
	DialogContent,
	DialogDescription,
	DialogFooter,
	DialogHeader,
	DialogTitle,
} from '@repo/ui/components/ui/Dialog';
import {
	Cropper,
	CropperArea,
	CropperAreaData,
	CropperImage,
	CropperPoint,
	CropperProps,
} from '@repo/ui/components/ui/Cropper';
import { Label } from '@repo/ui/components/ui/Label';
import { Slider } from '@repo/ui/components/ui/Slider';
import { Button } from '@repo/ui/components/ui/Button';

interface CropProfilePictureDialogProps {
	showCropDialog: boolean;
	onCropDialogOpenChange: (open: boolean) => void;
	selectedFileName?: string;
	selectedImageUrl?: string | null;
	onCrop: (image: File) => void;
	canClose?: boolean;
}

async function createCroppedImage(
	imageSrc: string,
	cropData: CropperAreaData,
	fileName: string,
): Promise<File> {
	const image = new Image();
	image.crossOrigin = 'anonymous';

	return new Promise((resolve, reject) => {
		image.onload = () => {
			const canvas = document.createElement('canvas');
			const ctx = canvas.getContext('2d');

			if (!ctx) {
				reject(new Error('Could not get canvas context'));
				return;
			}

			canvas.width = cropData.width;
			canvas.height = cropData.height;

			ctx.drawImage(
				image,
				cropData.x,
				cropData.y,
				cropData.width,
				cropData.height,
				0,
				0,
				cropData.width,
				cropData.height,
			);

			canvas.toBlob((blob) => {
				if (!blob) {
					reject(new Error('Canvas is empty'));
					return;
				}

				const croppedFile = new File([blob], `cropped-${fileName}`, {
					type: 'image/png',
				});
				resolve(croppedFile);
			}, 'image/png');
		};

		image.onerror = () => reject(new Error('Failed to load image'));
		image.src = imageSrc;
	});
}

const CropProfilePictureDialog = ({
	showCropDialog,
	onCropDialogOpenChange,
	selectedFileName,
	selectedImageUrl,
	onCrop,
	canClose = true,
}: CropProfilePictureDialogProps) => {
	const [zoom, setZoom] = React.useState(1);
	const [crop, setCrop] = React.useState<CropperPoint>({ x: 0, y: 0 });
	const [croppedArea, setCroppedArea] =
		React.useState<CropperAreaData | null>(null);

	useEffect(() => {
		if (!canClose) {
			// eslint-disable-next-line react-hooks/set-state-in-effect
			setZoom(1);
			setCrop({ x: 0, y: 0 });
		}
	}, [canClose]);

	const onCropAreaChange: NonNullable<CropperProps['onCropAreaChange']> =
		React.useCallback((_, croppedAreaPixels) => {
			setCroppedArea(croppedAreaPixels);
		}, []);

	const onCropReset = React.useCallback(() => {
		setCrop({ x: 0, y: 0 });
		setZoom(1);
		setCroppedArea(null);
	}, []);

	const onCropApply = React.useCallback(async () => {
		if (!selectedFileName || !croppedArea || !selectedImageUrl) return;

		try {
			const croppedFile = await createCroppedImage(
				selectedImageUrl,
				croppedArea,
				selectedFileName,
			);

			onCrop(croppedFile);
			onCropDialogOpenChange(false);
		} catch (error) {
			toast.error(
				error instanceof Error ? error.message : 'Failed to crop image',
			);
		}
	}, [
		selectedFileName,
		croppedArea,
		selectedImageUrl,
		onCropDialogOpenChange,
		onCrop,
	]);

	return (
		<Dialog open={showCropDialog} onOpenChange={onCropDialogOpenChange}>
			<DialogContent
				showCloseButton={canClose}
				onInteractOutside={(event) => {
					if (!canClose) {
						event.preventDefault();
					}
				}}
				onEscapeKeyDown={(event) => {
					if (!canClose) {
						event.preventDefault();
					}
				}}
				className='max-w-4xl'
			>
				<DialogHeader>
					<DialogTitle>Crop Image</DialogTitle>
					<DialogDescription>
						Adjust the crop area and zoom level for{' '}
						{selectedFileName}
					</DialogDescription>
				</DialogHeader>
				{selectedFileName && selectedImageUrl && (
					<div className='relative flex size-full flex-col gap-4'>
						<Cropper
							aspectRatio={1}
							shape='circle'
							crop={crop}
							onCropChange={setCrop}
							zoom={zoom}
							onZoomChange={setZoom}
							onCropAreaChange={onCropAreaChange}
							onCropComplete={onCropAreaChange}
							className='h-96'
							//allowOverflow
						>
							<CropperImage
								src={selectedImageUrl}
								alt={selectedFileName}
								crossOrigin='anonymous'
							/>
							<CropperArea />
						</Cropper>
						<div className='flex flex-col gap-2'>
							<Label className='text-sm'>
								Zoom: {zoom.toFixed(2)}
							</Label>
							<Slider
								value={[zoom]}
								onValueChange={(value) =>
									setZoom(value[0] ?? 1)
								}
								min={1}
								max={3}
								step={0.1}
								className='w-full'
							/>
						</div>
					</div>
				)}
				<DialogFooter>
					<Button onClick={onCropReset} variant='outline'>
						Reset
					</Button>
					<Button onClick={onCropApply} disabled={!croppedArea}>
						Crop
					</Button>
				</DialogFooter>
			</DialogContent>
		</Dialog>
	);
};

export default CropProfilePictureDialog;
