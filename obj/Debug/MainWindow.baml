   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:EncoderDecoderEncoderDecoder  5   	       EncoderDecoder.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:EncoderDecoder     5   	   -   5          � Title$  
MainWindow��5	   	   $	��250��6   $��685.929��6)   .��5
      � .+�5   
   �� -   5        $��Label1��5      $��Decrypt File :��6   $
��Left=�67   $��	10,10,0,0q�6R   $	��Top=�6e   $��26��6}   �� 5   
   -   5        $��TextBox1��5      $
��Left=�6"   $��20��6=   $��
123,16,0,0q�6I    �� TextWrapping$
 Wrap=�6]   $�� ��6q   $	��Top=�6y   $	��457��6�   	� 5   
   -   5        $��DecryptRadioBtn��5      $��Decrypt��6-   $
��Left=�6?   $��
99,120,0,0q�6Z   $	��Top=�6n   6�   	� 5   
   -   5        $��EncryptRadioBtn��5      $��Encrypt��6-   $
��Left=�6?   $��
10,120,0,0q�6Z   $	��Top=�6n    d� 	IsChecked$
 TrueY�6�   6�   �� 5   
   -   5         ��Name$ ActionButton��5      $��Encrypt��6'   $
��Left=�69   $��
10,161,0,0q�6T   $	��Top=�6h   $	��108��6�   $��36��6�   6�   �� 5   
   $��Decryption key :��6   $
��Left=�6+   $��	10,74,0,0q�6F   $	��Top=�6Y   �� 5   
   -   5        $��	ComboBox1��5      $
��Left=�6$   $��
391,78,0,0q�6?   $	��Top=�6S   $	��170��6k   �� 5   
   $��Encrypt type :��6   $
��Left=�6)   $��
304,74,0,0q�6D   $	��Top=�6X   � 5   
   -   5         �Name$ ProgressBar��5      $
��Left=�6+   $��21��6F   $��
23,140,0,0q�6R   $	��Top=�6f   $	��297��6~   $y�Hidden=�6�   �� 5   
   -	   5        $��OpenBtn1��5      $
��Open��6!   $
��Left=�60   $��
585,16,0,0q�6K   $	��Top=�6_   $��75��6w   6�   �� 5   
   -
   5        $��Label2��5      $��Encrypt File :��6    $
��Left=�69   $��	10,36,0,0q�6T   $	��Top=�6g   $��26��6   �� 5   
   -   5         ��Name$ TextBox2��5       J� 	AllowDrop . $
��Left=�65   $��20��6P   $��
123,42,0,0q�6\   $
 Wrap=�6p   $�� ��6�   $	��Top=�6�   $	��457��6�   �� 5   
   -   5        $ OpenBtn1_Copy��5      $
��Open��6(   $
��Left=�67   $��
585,42,0,0q�6R   $	��Top=�6f   $��75��6~   6�   G� 5   
   -   5         G�Name$ PasswordBox��5      $
��Left=�6+   $��
123,80,0,0q�6F   $	��Top=�6Z   $	��176��6r   ���#dcd6f76~   5      5      