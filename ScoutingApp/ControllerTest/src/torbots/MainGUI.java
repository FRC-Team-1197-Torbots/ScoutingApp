package torbots;
import javax.swing.JLabel;
import java.awt.BorderLayout;
import java.awt.Font;
import javax.swing.JPanel;
import javax.swing.JTable;
import javax.swing.JTextField;
import javax.swing.BoxLayout;
import java.awt.GridLayout;

/**
 * The MainGUI class provides the code for the graphical interface for the scouting app.
 */

public class MainGUI extends javax.swing.JFrame {
	private JTextField textField;
	private JTextField textField_1;
	private JTextField textField_2;
	private JTextField textField_3;
	private JTextField textField_4;
	private JTextField textField_5;
	
	public MainGUI(){ 
		JLabel lblTorbotsScoutingApp = new JLabel("TorBots Scouting App");
		lblTorbotsScoutingApp.setFont(new Font("Arial", Font.PLAIN, 30));
		getContentPane().add(lblTorbotsScoutingApp, BorderLayout.NORTH);
		
		JPanel panel = new JPanel();
		getContentPane().add(panel, BorderLayout.WEST);
		panel.setLayout(new GridLayout(0, 1, 0, 0));
		
		JLabel lblController = new JLabel("Controller 1");
		lblController.setFont(new Font("MS UI Gothic", Font.BOLD, 18));
		panel.add(lblController);
		
		JLabel lblButtonA = new JLabel("Button A");
		panel.add(lblButtonA);
		
		textField = new JTextField();
		panel.add(textField);
		textField.setColumns(10);
		
		JLabel lblButtonB = new JLabel("Button B");
		panel.add(lblButtonB);
		
		textField_1 = new JTextField();
		panel.add(textField_1);
		textField_1.setColumns(10);
		
		JLabel lblButtonC = new JLabel("Button X");
		panel.add(lblButtonC);
		
		textField_2 = new JTextField();
		panel.add(textField_2);
		textField_2.setColumns(10);
		
		JLabel lblButtonD = new JLabel("Button Y");
		panel.add(lblButtonD);
		
		textField_3 = new JTextField();
		panel.add(textField_3);
		textField_3.setColumns(10);
		
		JLabel lblLeftTrigger = new JLabel("Left Trigger");
		panel.add(lblLeftTrigger);
		
		textField_4 = new JTextField();
		panel.add(textField_4);
		textField_4.setColumns(10);
		
		JLabel lblRightTrigger = new JLabel("Right Trigger");
		panel.add(lblRightTrigger);
		
		textField_5 = new JTextField();
		panel.add(textField_5);
		textField_5.setColumns(10);
		
	}

}
