public class hello extends javax.swing.JFrame 
{
    private javax.swing.JLabel helloLabel;
    private javax.swing.JButton exitButton;
    private javax.swing.JButton btnRechnen;
    
    public hello() 
    {
        initComponents();
    }
    
    private void initComponents() 
    {
        helloLabel = new javax.swing.JLabel();
        exitButton = new javax.swing.JButton();
        getContentPane().setLayout(null);
        setTitle("Hello");
        addWindowListener(new java.awt.event.WindowAdapter() {
            public void windowClosing(java.awt.event.WindowEvent evt) {
                exitForm(evt);
            }
        });

        helloLabel.setText("Hallo, ich bin ein Java-Programm");
        getContentPane().add(helloLabel);
        helloLabel.setBounds(20, 20, 200, 16);

        exitButton.setText("Beenden");
        exitButton.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                exitButtonActionPerformed(evt);
            }
        });
        getContentPane().add(exitButton);
        exitButton.setBounds(20, 120, 87, 26);

        pack();
        java.awt.Dimension screenSize = java.awt.Toolkit.getDefaultToolkit().getScreenSize();
        setSize(new java.awt.Dimension(264, 191));
        setLocation((screenSize.width-264)/2,(screenSize.height-191)/2);
    }

    private void exitButtonActionPerformed(java.awt.event.ActionEvent evt) 
    {
       dispose();
    }
    
    private void exitForm(java.awt.event.WindowEvent evt)
    {
        System.exit(0);
    }
    
    public static void main(String args[]) 
    {
        new hello().show();
    }
}
