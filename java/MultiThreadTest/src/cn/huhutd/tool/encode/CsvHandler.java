package cn.huhutd.tool.encode;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.CopyOnWriteArrayList;

public class CsvHandler {

	public static void main(String[] args) {
		CopyOnWriteArrayList<String> aaa = new CopyOnWriteArrayList<String>();
		String file = "/Users/zch/Desktop/001.csv";
		List<Integer> bin = convertString2Int(file);

		minusSingle(bin);
		System.out.println("--------------");
		for (Integer i : bin) {
			System.out.print(i + " ");
		}
		System.out.println("--------------");
		List<TmpClass> tmpList = handleLen(bin);
		for (TmpClass tmpClass : tmpList) {
			System.out.println(tmpClass.value + ":" + tmpClass.num);
		}
	}

	public static List<TmpClass> handleLen(List<Integer> data) {
		List<TmpClass> ret = new ArrayList<TmpClass>();
		int current = data.get(0);
		int num = 0;
		for (int i = 0; i < data.size(); i++) {
			num++;
			if (current == data.get(i)) {
			} else {
				TmpClass tc = new TmpClass();
				ret.add(tc);
				tc.num = num;
				tc.value = current;
				num = 0;
				current = data.get(i);
			}
		}
		return ret;
	}

	/**
	 * 去掉不符合规则的数据
	 * 
	 * @param data
	 * @return
	 */
	public static void minusSingle(List<Integer> data) {
		for (int i = 1; i < data.size() - 1; i++) {

			if (data.get(i) == 0) {
				if (data.get(i - 1) == 1 && data.get(i + 1) == 1) {
					data.set(i, 1);
				}
			}
		}
	}

	public static List<Integer> convertString2Int(String file) {
		List<String> lines = readFile(file);
		List<Integer> ret = new ArrayList<Integer>(lines.size());
		for (String s : lines) {
			double d = Double.parseDouble(s);
			if (Math.abs(d) < 0.2) {
				ret.add(0);
			} else {
				ret.add(1);
			}
		}
		return ret;
	}

	private static List<String> readFile(String fileName) {
		List<String> dataList = new ArrayList<String>(300000);
		BufferedReader reader = null;
		try {
			reader = new BufferedReader(new FileReader(fileName));
			String tempString = null;
			while ((tempString = reader.readLine()) != null) {
				dataList.add(tempString);
			}
			reader.close();
		} catch (IOException e) {
			e.printStackTrace();
		} finally {
			if (reader != null) {
				try {
					reader.close();
				} catch (IOException e1) {
				}
			}
		}
		return dataList;
	}

	public static List<Integer> ConvertDouble2Int() {
		return null;
	}

}

class TmpClass {
	public int value;
	public int num;
}
