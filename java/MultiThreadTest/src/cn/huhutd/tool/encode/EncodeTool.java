package cn.huhutd.tool.encode;

import java.util.ArrayList;
import java.util.List;

public class EncodeTool {
	
	public static int[] getCode(int userCode, int dataCode) throws Exception {
		int[] bin = convertCode2Binary(userCode, dataCode);
		for (int i = 0; i < bin.length; i++) {
			System.out.print(bin[i] + " ");
		}
		System.out.println("");

		int[] aaa = convertBinary2IntArray(bin);
		for (int i = 0; i < aaa.length; i++) {
			System.out.print(aaa[i] + " ");
		}
		return aaa;
	}
	
	public static void main(String[] args) throws Exception {
		short userCode = 0x33B8;
		int dataCode = 0xF9;
		
		getCode(userCode, dataCode);
	}

	/**
	 * 传入类似 0 1 1 0，传出android里面transmit需要的参数。
	 * 
	 * @param data
	 * @return
	 * @throws Exception
	 */
	public static int[] convertBinary2IntArray(int[] data) throws Exception {
		if (data.length != 32) {
			throw new Exception("参数错误,应该是32位");
		}
		int[] ret = new int[66];
		ret[0] = 9000;
		ret[1] = 4500;
		int j = 2;
		for (int i = 0; i < data.length; i++) {
			if (data[i] == 0) {
				ret[j] = 560;
				ret[j + 1] = 560;
			} else if (data[i] == 1) {
				ret[j] = 560;
				ret[j + 1] = 1680;
			} else {
				System.out.println("error");
				throw new Exception("参数错误");
			}
			j++;
			j++;
		}
		return ret;
	}

	/**
	 * 传入FF，传出11111111
	 * 
	 * @param input
	 * @param length
	 * @return
	 */
	public static int[] convertIntegery2Binary(int input, int length) {
		int[] ret = new int[length];
		String s1 = Integer.toBinaryString(input);
		int len = length - s1.length();
		int i = 0;
		for (;;) {
			if (i == len) {
				break;
			}
			ret[i] = 0;
			i++;
		}
		char[] charArray = s1.toCharArray();
		for (char c : charArray) {
			ret[i] = Integer.valueOf(c + "");
			i++;
		}
		return ret;
	}

	/**
	 * 取反码
	 * 
	 * @param input
	 * @return
	 */
	public static int convertNegetiveCode(int input) {
		String hexString = Integer.toHexString(input);
		int ret = 0;
		char[] charArray = hexString.toCharArray();
		int len = charArray.length;
		for (int i = 0; i < len; i++) {
			int tmp = (Integer.valueOf(charArray[i] + "", 16));
			int t2 = (0xF - tmp) << ((len - 1 - i) * 4);
			ret += t2;
		}

		return ret;
	}

	/**
	 * 把用户码和数据码变成二进制
	 * @param userCode
	 * @param dataCode
	 * @return
	 */
	public static int[] convertCode2Binary(int userCode, int dataCode) {
		int[] ret = new int[32];

		int[] array1 = convertIntegery2Binary(userCode, 16);
		System.arraycopy(array1, 0, ret, 0, array1.length);
		int[] array2 = convertIntegery2Binary(dataCode, 8);
		System.arraycopy(array2, 0, ret, 16, array2.length);
		int[] array3 = convertIntegery2Binary(convertNegetiveCode(dataCode), 8);
		System.arraycopy(array3, 0, ret, 24, array3.length);
		return ret;
	}

	public static int[] convertShort2Int(short[] sarray) {
		List<Integer> codes = new ArrayList<Integer>();

		short previous = sarray[0];
		int value = 0;
		for (int i = 0; i < sarray.length; i++) {
			if (previous != sarray[i]) {
				codes.add(value);
				value = 0;
			}
			value++;
			previous = sarray[i];
			if (i == sarray.length - 1) {
				codes.add(value);
			}
		}
		int[] ret = new int[codes.size()];
		for (int i = 0; i < ret.length; i++) {
			ret[i] = (int) (11.4 * codes.get(i));
		}
		return ret;
	}

	public static boolean is1(int input) {
		return Math.abs(input - 560) < 10;
	}

	public static boolean is3(int input) {
		return Math.abs(input - 1698) < 20;
	}

	public static List<Integer> convert2Nec(int[] input) {
		List<Integer> ret = new ArrayList<Integer>(100);
		int i = 0;
		int len = input.length;
		for (;;) {
			if (i >= len - 1) {
				break;
			}
			if (is1(input[i])) {
				if (is1(input[i + 1])) {
					ret.add(0);
					i++;
					i++;
					continue;
				} else if (is3(input[i + 1])) {
					ret.add(1);
					i++;
					i++;
					continue;
				}
			}

			ret.add(input[i]);
			i++;
		}
		return ret;
	}
}
