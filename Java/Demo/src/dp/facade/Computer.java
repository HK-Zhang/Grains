package dp.facade;

public class Computer {
	private CPU cpu;
	private Memory memory;
	private Disk disk;
	
	public Computer() {
		cpu = new CPU();
		memory = new Memory();
		disk = new Disk();
	}
	
	public void startup() {
		cpu.StartUp();
		memory.StartUp();
		disk.StartUp();
	
	}
	
	public void shutdown() {
		cpu.ShutDown();
		memory.ShutDown();
		disk.ShutDown();
	}

}
