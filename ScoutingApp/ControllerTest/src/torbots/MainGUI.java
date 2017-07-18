package torbots;
import javax.swing.JLabel;
import java.awt.BorderLayout;
import java.awt.Font;

/**
 * The MainGUI class provides the code for the graphical interface for the scouting app.
 */

public class MainGUI extends javax.swing.JFrame {
	
	public MainGUI(){ 
		// Adding the title label
		JLabel lblTorbotsScoutingApp = new JLabel("TorBots Scouting App");
		lblTorbotsScoutingApp.setFont(new Font("Arial", Font.PLAIN, 30));
		getContentPane().add(lblTorbotsScoutingApp, BorderLayout.NORTH);
		
	}

}
