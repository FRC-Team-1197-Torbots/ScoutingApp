package torbots;

import org.lwjgl.input.Controllers;

public class Scouter {

	private Scout[] scouts;
	
	private boolean Calibrated;
	private boolean Running;
	
	public Scouter() {	
		//Initialize Scouts
		scouts = new Scout[6];
		for(int i = 0; i < scouts.length; i++) {
			scouts[i] = new Scout();
		}

		//initialize booleans
		Calibrated = false;
		Running = false;
	}
	
	
	
	public void loop() {
		
		
		
		
	}
}
