import java.util.*;

interface Call_stages{
	public void dial(Telephone t);
	public void connect(Telephone t);
	public boolean busy(Telephone t);
	public void ring(Telephone t);
	public void disconnect(Telephone t);
}

class Telephone implements Call_stages{
	public String phone_number;
	public boolean ringing = false;
	public boolean pickup = false;
	public boolean dialling = false;

	Telephone(String ph_no){
		this.phone_number = ph_no;
	}

	@java.lang.Override
	public boolean busy(Telephone t) {
		if(t.pickup==true || t.ringing==true || t.dialling==true){
			System.out.println("Message to "+phone_number + " : " + t.phone_number +" number is busy on other call, call again later....");
			return true;
		}
		return false;
	}

	@java.lang.Override
	public void connect(Telephone t) {
		System.out.println("Message for "+phone_number+" : You are now on call with "+ t.phone_number);
	}

	@java.lang.Override
	public void dial(Telephone t) {
		dialling = true;
		if(busy(t)){
		}
		else{
			ring(t);
		}
	}

	@java.lang.Override
	public void disconnect(Telephone t) {
		pickup = false;
		t.pickup = false;
		dialling = false;
		System.out.println("Message for "+ phone_number+ ": Disconnecting call with "+t.phone_number);
	}

	@java.lang.Override
	public void ring(Telephone t) {
		t.ringing = true;
		System.out.println("Message for "+ phone_number+ ": "+ t.phone_number+" is ringing...");
		t.ringing = false;
		t.pickup = true;
		pickup = true;
		System.out.println("Message for "+ phone_number+ ": "+ t.phone_number+" has picked your call");
		connect(t);
	}
}

public class TeleApp{
	public static void main(String [] args){
		Telephone t1 = new Telephone("123");
		Telephone t2 = new Telephone("234");
		Telephone t3 = new Telephone("345");

		t1.dial(t3);

		t2.dial(t3); //This call will not happen till the previous call disconnects

		t1.disconnect(t3);

		t2.dial(t3); // Now this call is possible as t3 is not on any call now

		t2.disconnect(t3);
	}
}