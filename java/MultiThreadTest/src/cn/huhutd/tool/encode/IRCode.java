package cn.huhutd.tool.encode;

import java.util.ArrayList;
import java.util.List;

public class IRCode {

	public int[] getCode1() {
		int[] ret = new int[71];
		ret[0] = 9000;
		ret[1] = 4500;

		int[] code = new int[32];
		List<Integer> list = new ArrayList<Integer>();
		list.add(2);
		list.add(3);
		list.add(6);
		list.add(7);
		list.add(8);
		list.add(10);
		list.add(11);
		list.add(12);
		list.add(17);
		list.add(18);
		list.add(24);
		list.add(27);

		list.add(28);
		list.add(29);
		list.add(30);
		list.add(31);
		for (Integer i : list) {
			code[i] = 1;
		}
		for (int i = 0; i < 32; i++) {
			ret[i * 2 + 2] = 560;
			ret[i * 2 + 3] = code[i] == 0 ? 560 : 1680;
		}
		ret[66] = 560;
		ret[67] = 39204;
		ret[68] = 9040;
		ret[69] = 4514;
		ret[70] = 560;
		 

		return ret;
	}

	public int[] getCode() {
		short[] sarray = this.getWave((short) 0x33B8, (byte) 0xF9);

		return EncodeTool.convertShort2Int(sarray);
	}

	

	public static void main(String[] args) {
		IRCode inst = new IRCode();
		int[] arr = inst.getCode();
		arr = inst.getCode1();
		for (int i : arr) {
			System.out.println(i);
		}
	}

	// WaveService wave = new WaveService();
	private final String LOG_TAG = "WaveService";
	private final boolean mDebug = false;
	private final int duration = 10; // seconds

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

	protected void onCreate() {

		playSound((short) 0x33B8, (byte) 0xA0);

		getWave((short) 0x33B8, (byte) 0x79);

	}

	private void playSound(short userCode, byte dataCode) {
		short[] dst = new short[44100];
		short[] recieve = getWave(userCode, dataCode);
		for (int i = 0; i < recieve.length; i++) {
			dst[i] = recieve[i];

		}

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
			// generatedSnd[i] = (short)(8000*percent*Math.sin(2* Math.PI* freqOfTone* i*
			// 1000/sampleRate)+(percent *20000));
			// generatedSnd[i] = (short)(30000*percent*Math.sin(2* Math.PI* freqOfTone* i*
			// 1000/sampleRate));
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
	 * 注释作者：xgh 时间：2017.10.23 作用：得到NEC消息帧的中红外协议的设备ID 参数：userCode:设备ID 返回：设备ID编码数组
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
	public short[] getWave(short userCode, byte dataCode) {

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

}
