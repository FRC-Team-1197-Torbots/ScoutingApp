package torbots;

import org.lwjgl.LWJGLException;
import org.lwjgl.input.Controller;
import org.lwjgl.input.Controllers;

public class ScoutingAppMain {

	public static void main(String[] args) {

		Controller controller;
		
		try {
			Controllers.create();
		} catch (LWJGLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		Controllers.poll();
		
		int controllernum = -1;
		
		for(int i = 0; i < Controllers.getControllerCount(); i++) {
			System.out.println(Controllers.getController(i).getName());
			
			//For now we are only looking for the first controller
			if(Controllers.getController(i).getName().contains("Controller")) {
				controllernum = i;
				break;
			}
		}
		
		if(controllernum >= 0) {
			controller = Controllers.getController(controllernum);
		} else {
			System.err.println("There is no  recognized controller");
			return;
		}
		
		
		while(true) {
			controller.poll();
			
			if(controller.isButtonPressed(0)) {        //A
				System.out.println("Button 0 Pressed"); 
			} else if(controller.isButtonPressed(1)) { //B
				System.out.println("Button 1 Pressed");
			} else if(controller.isButtonPressed(2)) { //X
				System.out.println("Button 2 Pressed");
			} else if(controller.isButtonPressed(3)) { //Y
				System.out.println("Button 3 Pressed");
			} else if(controller.isButtonPressed(4)) { //Left Trigger
				System.out.println("Button 4 Pressed");
			} else if(controller.isButtonPressed(5)) {
				System.out.println("Button 5 Pressed"); //Right Trigger
			}
		}
	}

}
