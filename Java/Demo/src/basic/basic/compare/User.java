package basic.compare;

public class User implements Comparable {
	private String Id;
	private int age;
	
	public int getAge() {
		return age;
	}
	
	public void setAge(int age) {
		this.age = age;
	}
	
	public String getId() {
		return Id;
	}
	public void setId(String id) {
		Id = id;
	}
	
	public User(String Id, int age) {
		this.Id=Id;
		this.age=age;
	}

	@Override
	public int compareTo(Object o) {
		return this.age-((User) o).age;
	}

}
