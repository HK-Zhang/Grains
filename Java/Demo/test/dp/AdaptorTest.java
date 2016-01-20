package dp;

import dp.adaptor.*;

public class AdaptorTest {

	public static void main(String[] args) {
		ITargetable iTargetable = new AdaptorViaCls();
		iTargetable.method1();
		iTargetable.method2();
		
		Source source = new Source();
		ITargetable warper = new Wraper(source);
		warper.method1();
		warper.method2();
		
		ISourceable ssub1= new SourceSub1();
		ISourceable ssub2 = new SourceSub2();
		ssub1.Method1();
		ssub1.Method2();
		ssub2.Method1();
		ssub2.Method2();
	

	}

}
