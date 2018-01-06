package com.hhtd.audioplayer;

import java.awt.Button;
import java.io.File;
import java.util.ArrayList;
import java.util.List;

import javax.sound.sampled.AudioFormat;
import javax.sound.sampled.AudioFormat.Encoding;
import javax.sound.sampled.AudioInputStream;
import javax.sound.sampled.AudioSystem;
import javax.sound.sampled.DataLine;
import javax.sound.sampled.SourceDataLine;

public class App {

	private void playSound(byte[] content) throws Exception {
		AudioFormat format = new AudioFormat(Encoding.PCM_SIGNED, 44100.0f, 24, 2, 6, 44100.0f, false);
		DataLine.Info info = new DataLine.Info(SourceDataLine.class, format);
		SourceDataLine line = (SourceDataLine) AudioSystem.getLine(info);
		line.open(format);// 或者line.open();format参数可有可无
		line.start();
		line.write(content, 0, content.length);
		line.drain();
		line.close();
	}

	private byte[] convertShortArray(short[] shortArray) {
		byte[] ret = new byte[shortArray.length * 2];
		int i = 0;
		for (i = 0; i < shortArray.length; i++) {
			ret[i * 2] = (byte) (shortArray[i] & 0xff);
			ret[i * 2 + 1] = (byte) ((shortArray[i] >> 8) & 0xff);
		}
		return ret;
	}


	private byte[] readContent(String file) throws Exception {
		List<Byte> data = new ArrayList<Byte>();
		AudioInputStream cin = AudioSystem.getAudioInputStream(new File(file));
		int nBytesRead = 0;
		byte[] buffer = new byte[512];
		while (true) {
			nBytesRead = cin.read(buffer, 0, buffer.length);
			if (nBytesRead <= 0)
				break;
			for (int i = 0; i < nBytesRead; i++) {
				data.add(buffer[i]);
			}
		}
		byte[] ret = new byte[data.size()];
		int i = 0;
		for (Byte b : data) {
			ret[i] = b;
			i++;
		}
		return ret;
	}

	private void playWavTest() throws Exception {
		byte[] data = this.readContent("/Users/zch/tmp/qqqq.wav");
		this.playSound(data);
	}

	private void playWav() throws Exception {
		String file = "/Users/zch/tmp/qqqq.wav";
		AudioInputStream cin = AudioSystem.getAudioInputStream(new File(file));
		AudioFormat format = cin.getFormat();
		DataLine.Info info = new DataLine.Info(SourceDataLine.class, format);
		SourceDataLine line = (SourceDataLine) AudioSystem.getLine(info);
		line.open(format);// 或者line.open();format参数可有可无
		line.start();
		int nBytesRead = 0;
		byte[] buffer = new byte[512];
		while (true) {
			nBytesRead = cin.read(buffer, 0, buffer.length);
			if (nBytesRead <= 0)
				break;
			line.write(buffer, 0, nBytesRead);
		}
		line.drain();
		line.close();
	}

	public static void main(String[] args) throws Exception {
		App app = new App();
		// app.playWav();

		app.create();
	}


	private void create() throws Exception {
		for (int i = 0; i < 1; i++) {
			playSound((short) 0x33B8, (byte) 0xF9);
			System.out.println("33B8F9 频道-");
		}
		for (int i = 0; i < 2; i++) {
			// playSound((short) 0x33B8, (byte) 0x77);
			// System.out.println("33B877 频道-");
		}
	}

	/*
	 * 注释作者：xgh 时间：2017.10.23 作用：播放声音，将最终信号通过耳机口发送出去 参数： userCode：设备ID编号
	 * dataCode：指令数据码 返回：无
	 */
	private void playSound(short userCode, byte dataCode) throws Exception {
		short[] dst = new short[44100];
		short[] recieve = getWave(userCode, dataCode);

		for (int i = 0; i < recieve.length; i++) {
			dst[i] = recieve[i];
			System.out.print(recieve[i]);
		}

		byte[] data = this.convertShortArray(dst);
		this.playSound(data);

	}

	/*
	 * 注释作者：xgh 时间：2017.10.23 作用：得到一段时间内的指定占空比的正弦信号的PCM编码 参数： time ：时间
	 * percent：指代红外编码的高低电平 返回：编码结果
	 */

	private short[] genTone(double time, float percent) {
		int numSamples = (int) (time / 1000 * sampleRate);
		short generatedSnd[] = new short[numSamples];

		// fill out the array
		for (int i = 0; i < numSamples; ++i) {
			// generatedSnd[i] = (short)(8000*percent*Math.sin(2* Math.PI*
			// freqOfTone* i* 1000/sampleRate)+(percent *20000));
			// generatedSnd[i] = (short)(30000*percent*Math.sin(2* Math.PI*
			// freqOfTone* i* 1000/sampleRate));
			generatedSnd[i] = (short) (32000 * percent);
		}

		return generatedSnd;
	}

	/*
	 * 注释作者：xgh 时间：2017.10.23 作用：获取在NEC红外协议里定义的逻辑 0 ，即560us的载波+560us的低电平 参数：无
	 * 返回：NEC红外协议里定义的逻辑 0 的PCM编码数组
	 */
	private short[] getLow() {
		// (1.125-0.56) + 0.56
		// INFRARED_0_HIGH_WIDTH 0.56
		// INFRARED_0_LOW_WIDTH 0.565 // 1.125 - 0.56
		short[] one = genTone(INFRARED_0_HIGH_WIDTH, 1);
		short[] two = genTone(INFRARED_0_LOW_WIDTH, 0);
		short[] combined = new short[one.length + two.length];

		System.arraycopy(one, 0, combined, 0, one.length);
		System.arraycopy(two, 0, combined, one.length, two.length);
		return combined;
	}

	/*
	 * 注释作者：xgh 时间：2017.10.23 作用：获取在NEC红外协议里定义的逻辑 1 ，即560us的载波+1.69us的低电平 参数：无
	 * 返回：NEC红外协议里定义的逻辑 1 的PCM编码数组
	 */
	private short[] getHigh() {
		// 0.56ms + (2.25 - 0.56)
		// INFRARED_1_HIGH_WIDTH 0.56
		// INFRARED_1_LOW_WIDTH 1.69 // 2.25 - 0.56
		short[] one = genTone(INFRARED_1_HIGH_WIDTH, 1);
		short[] two = genTone(INFRARED_1_LOW_WIDTH, 0);
		short[] combined = new short[one.length + two.length];

		System.arraycopy(one, 0, combined, 0, one.length);
		System.arraycopy(two, 0, combined, one.length, two.length);
		return combined;
	}

	/*
	 * 注释作者：xgh 时间：2017.10.23 作用：得到NEC消息帧的开始编码 参数：无 返回：一帧消息的组成数组
	 */
	private short[] getleaderCode() {
		// 9.0ms + 4.50ms Infrared
		// INFRARED_LEADERCODE_HIGH_WIDTH 9.0
		// INFRARED_LEADERCODE_LOW_WIDTH 4.50
		short[] one = genTone(INFRARED_LEADERCODE_HIGH_WIDTH, 1);
		short[] two = genTone(INFRARED_LEADERCODE_LOW_WIDTH, 0);
		short[] combined = new short[one.length + two.length];

		System.arraycopy(one, 0, combined, 0, one.length);
		System.arraycopy(two, 0, combined, one.length, two.length);

		return combined;
	}

	/*
	 * 注释作者：xgh 时间：2017.10.23 作用：得到NEC消息帧的中红外协议的设备ID 参数：userCode:设备ID
	 * 返回：设备ID编码数组
	 */
	private short[] getUserCodeToWave(short userCode) {
		ArrayList<short[]> wave_list = new ArrayList<short[]>();
		int totalLength = 0;
		for (int i = 0; i < 16; ++i) { // 取最高位
			if (((userCode >> (15 - i)) & 0x1) == 1) { // 1
				wave_list.add(getHigh());
			} else { // 0
				wave_list.add(getLow());
			}
			totalLength += wave_list.get(i).length;
		}

		int currentPosition = 0;
		short userCodeWaveArray[] = new short[totalLength];

		for (short[] byteArray : wave_list) {
			System.arraycopy(byteArray, 0, userCodeWaveArray, currentPosition, byteArray.length);
			currentPosition += byteArray.length;
		}

		return userCodeWaveArray;
	}

	/*
	 * 注释作者：xgh 时间：2017.10.23 作用：得到NEC消息帧的中红外协议的数据码 参数：dataCode:指令数据 返回：指令数据编码数组
	 */
	private short[] getDataCodeToWave(byte dataCode) {
		ArrayList<short[]> wave_list = new ArrayList<short[]>();
		int totalLength = 0;
		// 取最高位
		for (int i = 0; i < 8; ++i) { // sign-and-magnitude
			if (((dataCode >> (7 - i)) & 0x1) == 1) { // 1
				wave_list.add(getHigh());
			} else { // 0
				wave_list.add(getLow());
			}
			totalLength += wave_list.get(i).length;
		}
		// 取最高位
		for (int i = 0; i < 8; ++i) { // ones'complement
			if (((dataCode >> (7 - i)) & 0x1) == 1) { // 1
				wave_list.add(getLow());
			} else { // 0
				wave_list.add(getHigh());
			}
			totalLength += wave_list.get(8 + i).length;
		}

		int currentPosition = 0;
		short userCodeWaveArray[] = new short[totalLength];
		for (short[] byteArray : wave_list) {
			System.arraycopy(byteArray, 0, userCodeWaveArray, currentPosition, byteArray.length);
			currentPosition += byteArray.length;
		}

		return userCodeWaveArray;
	}

	/*
	 * 注释作者：xgh 时间：2017.10.23 作用：得到NEC消息帧的中红外协议的停止位 参数：无 返回：指令数据编码数组
	 */
	private short[] getStopBit() {
		// 0.56ms
		// INFRARED_STOPBIT_HIGH_WIDTH 0.56
		return genTone(INFRARED_STOPBIT_HIGH_WIDTH, 1);
	}

	/*
	 * 注释作者：xgh 时间：2017.10.23 作用：制作一帧消息，将一帧消息中的所有组成添加到一个数组里 参数：无 返回：一帧消息的组成数组
	 */
	private short[] getWave(short userCode, byte dataCode) {
		if (mDebug)
			System.out.println(
					"userCode = 0x" + Integer.toHexString(userCode) + " dataCode = 0x" + Integer.toHexString(dataCode));
		ArrayList<short[]> wave_list = new ArrayList<short[]>();
		int totalLength = 0;

		// wave_list.add(getTou());
		wave_list.add(getleaderCode());
		wave_list.add(getUserCodeToWave(userCode));
		wave_list.add(getDataCodeToWave(dataCode));
		wave_list.add(getStopBit());
		wave_list.add(genTone(DELAY_WIDTH, 0));
		wave_list.add(getleaderCode());
		wave_list.add(getStopBit());

		for (short[] byteTmp : wave_list)
			totalLength += byteTmp.length;

		int currentPosition = 0;
		short totalWaveArray[] = new short[totalLength];

		for (short[] byteArray : wave_list) {
			System.arraycopy(byteArray, 0, totalWaveArray, currentPosition, byteArray.length);
			currentPosition += byteArray.length;
		}

		return totalWaveArray;
	}

	private short[] getTou() {
		ArrayList<short[]> wave_list = new ArrayList<short[]>();
		int totalLength = 0;
		for (int i = 0; i < 3; ++i) {
			wave_list.add(genTone(10, 0)); // 10ms 0 //10ms的低电平编码

			// for(int j=1; j<4; ++j) { // 取最高位
			// wave_list.add(getLittleHigh());
			// }

			wave_list.add(genTone(10, 0)); // 10ms 0
		}

		for (short[] byteTmp : wave_list)
			totalLength += byteTmp.length;

		int currentPosition = 0;
		short userCodeWaveArray[] = new short[totalLength];

		for (short[] byteArray : wave_list) {
			System.arraycopy(byteArray, 0, userCodeWaveArray, currentPosition, byteArray.length);
			currentPosition += byteArray.length;
		}

		return userCodeWaveArray;
	}

	/*
	 * 注释作者：xgh 时间：2017.10.23 作用：唔。。暂时还不知道作用 参数：无 返回：不知作用的数组
	 */
	private short[] getLittleHigh() {
		short[] one = genTone(INFRARED_1_LOW_WIDTH, 0.08f);
		short[] two = genTone(INFRARED_1_HIGH_WIDTH, 0);
		short[] combined = new short[one.length + two.length];

		System.arraycopy(one, 0, combined, 0, one.length);
		System.arraycopy(two, 0, combined, one.length, two.length);
		return combined;
	}

	// WaveService wave = new WaveService();
	private final String LOG_TAG = "WaveService";
	private final boolean mDebug = false;
	private final int duration = 10; // seconds
	private Button Btn_r;
	/**
	 * 音频采样频率，在录音中同样会有类似参数；通俗讲是每秒进行44100次采样。
	 * 详见：http://en.wikipedia.org/wiki/44,100_Hz
	 */
	private final int sampleRate = 44100;
	private int numSamples = duration * sampleRate;
	// private final double sample[] = new double[numSamples];
	private final double freqOfTone = 25000; // hz 20000=>20khz(50us) 最高0.56f ;

	// private final byte generatedSnd[] = new byte[2 * numSamples];
	/** Data "1" 高电平宽度 */
	private final float INFRARED_1_HIGH_WIDTH = 0.56f * 2;
	/** Data "1" 低电平宽度 */
	private final float INFRARED_1_LOW_WIDTH = 1.69f * 2; // 2.25 - 0.56
	/** Data "0" 高电平宽度 */
	private final float INFRARED_0_HIGH_WIDTH = 0.56f * 2;
	/** Data "0" 低电平宽度 */
	private final float INFRARED_0_LOW_WIDTH = 0.565f * 2;// 1.125-0.56
	/** Leader code 高电平宽度 */
	private final float INFRARED_LEADERCODE_HIGH_WIDTH = 9.0f * 2;
	/** Leader code 低电平宽度 */
	private final float INFRARED_LEADERCODE_LOW_WIDTH = 4.50f * 2;
	/** Stop bit 高电平宽度 */
	private final float INFRARED_STOPBIT_HIGH_WIDTH = 0.56f * 2;
	/** Stop bit 高电平宽度 */
	private final float DELAY_WIDTH = 78;
}
