package com.hhtd.audioplayer;

import java.io.IOException;

import com.google.zxing.WriterException;

public class QRCodeMain {
	public static void main(String[] args) throws IOException, WriterException {
		QRCodeImage.generateQRCodeImage("hello qr code", 500);
	}
}
