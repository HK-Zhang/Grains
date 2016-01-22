package dp;

import dp.decorator.*;
import dp.bridge.*;

public class BridgeTest {

	public static void main(String[] args) {
		Bridge bridge = new MyBridge();
		
		ISourceable src1 = new SourceSub1();
		bridge.setSource(src1);
		bridge.method();
		
		ISourceable src2 = new SourceSub2();
		bridge.setSource(src2);
		bridge.method();

	}

}
