   M S B A M L   `   `   `  ����L  HPOP-SF-60-2016GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:POP_SF_60_2016GUI.UIPOP_SF_60_2016GUI.UI  5   	   2    ,POP_SF_60_2016GUI.UI.EditDodatnaUslugaWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:POP_SF_60_2016GUI.UI     5   	     � Title$  EditDodatnaUslugaWindow��5   	   $	��200��6)   $	��300��66   ���	#FF374D35 � 
ResizeMode$ NoResize=�6Y   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��33* �6   �� 5      $	��40* �6    � RowDefinitions 5   
   �� 5      $	��54* �6   �� 5      $	��54* �6   �� 5      $	��65* �6   .+�5   
   �� -   5         ��Name$ label��5      $��Naziv usluge:��6   $��17(�67   $
��Left=�6E   $��33��6`   $��	10,10,0,0q�6l   $	��Top=�6   $	��112��6�   �� 5   
   -   5        $ label1��5      $��Cijena usluge:��6    $��17(�69   $
��Left=�6G   $��33��6b   $��	10,10,0,0q�6n   $��1��6�   $	��Top=�6�   $	��112��6�   �� 5   
   -   5         ��Name$ button��5      $��2��6!   $��Sacuvaj��65   $
��Left=�6G   $��
101,10,0,0q�6b   $��2��6v   $	��Top=�6�   $��80��6�   $��29��6�   6�   �� 5   
   -   5        $ button1��5      $��Zatvori��6"   $��1��64   $
��Left=�6D   $��	70,10,0,0q�6_   $��2��6r   $	��Top=�6   $��80��6�   $��29��6�   6�   �� 5   
   -   5         ��Name$ tbNaziv��5      $��1��6#   $
��Left=�63   $��33��6N   $��	10,10,0,0q�6Z    �� TextWrapping$
 Wrap=�6m   $	��Top=�6�   $	��140��6�   ��6�   ��  �� Path$ NazivUsluge�6�   �� 5   
   -   5        $ tbCijena��5      $��1��6$   $
��Left=�64   $��33��6O   $��	10,10,0,0q�6[   $��1��6n   $
 Wrap=�6{   $	��Top=�6�   $	��140��6�   ��6�   �� $ CijenaUsluge�6�   5      5      