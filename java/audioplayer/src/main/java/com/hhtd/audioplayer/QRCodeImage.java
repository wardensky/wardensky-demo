package com.hhtd.audioplayer;

import java.awt.Color;
import java.awt.Graphics;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;
import java.nio.file.FileSystems;
import java.nio.file.Path;
import java.util.HashMap;
import java.util.Map;

import javax.imageio.ImageIO;

import com.google.zxing.BarcodeFormat;
import com.google.zxing.EncodeHintType;
import com.google.zxing.MultiFormatWriter;
import com.google.zxing.WriterException;
import com.google.zxing.client.j2se.MatrixToImageWriter;
import com.google.zxing.common.BitMatrix;

public class QRCodeImage {
	public static int QR_IMG_SIZE = 150;
	public static String filePath = "";

	public static void generateQRCodeImage(String content) throws IOException, WriterException {
		generateQRCodeImage(content, 150);
	}

	public static void generateQRCodeImage(String content, int size) throws IOException, WriterException {
		mkdirs(filePath);
		QR_IMG_SIZE = size;
		drawOneQrImg(filePath, content);
	}

	private static void mkdirs(String path) {
		File file = new File(path);
		if (!file.exists()) {
			file.mkdirs();
		}
	}

	private static String drawOneQrImg(String filePath, String content) throws WriterException, IOException {
		String imageName = "code" + System.currentTimeMillis() + ".jpg";
		String format = "png";
		Map<EncodeHintType, Object> hints = new HashMap<EncodeHintType, Object>();
		hints.put(EncodeHintType.CHARACTER_SET, "UTF-8");

		BitMatrix bitMatrix = new MultiFormatWriter().encode(content, BarcodeFormat.QR_CODE, QR_IMG_SIZE, QR_IMG_SIZE,
				hints);
		Path path = FileSystems.getDefault().getPath(filePath, imageName);
		MatrixToImageWriter.writeToPath(bitMatrix, format, path);
		MatrixToImageWriter.toBufferedImage(bitMatrix);

		File qrFile = new File(filePath + imageName);
		BufferedImage qrImg = null;
		try {
			qrImg = ImageIO.read(qrFile);
			qrFile.delete();
		} catch (IOException e) {
			e.printStackTrace();
		}
		BufferedImage finalImage = new BufferedImage(QR_IMG_SIZE, QR_IMG_SIZE, BufferedImage.TYPE_INT_RGB);
		Graphics graphics = finalImage.createGraphics();
		graphics.setColor(Color.WHITE);
		graphics.drawImage(qrImg, 0, 0, null);

		String finalName = "code_" + System.currentTimeMillis() + ".jpg";
		File imgFile = new File(filePath + finalName);
		ImageIO.write(finalImage, "jpg", imgFile);
		return finalName;
	}

}
