   M S B A M L   `   `   `  ����L  HPOP-SF-60-2016GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:POP_SF_60_2016GUI.UIPOP_SF_60_2016GUI.UI  5   	   +    %POP_SF_60_2016GUI.UI.EditAkcijaWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:POP_SF_60_2016GUI.UI     5   	     � Title$  EditAkcijaWindow��5   	   $	��500��6"   $	��544��6/   ���	#FF374D35 � 
ResizeMode$ NoResize=�6R   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��110* �6   �� 5      $
��171* �6    � RowDefinitions 5   
   �� 5      $
��217* �6   �� 5      $	��60* �6   �� 5      $	��60* �6   �� 5      $	��60* �6   �� 5      $	��72* �6   .+�5   
   �� $��Popust: ��6   $
��Left=�6#   $��31��6>   $��	10,10,0,0q�6J   $��1��6]   $	��Top=�6j   $	��133��6�   �� 5   
   $��Namjestaj na akciji: ��6   $
��Left=�60   $��31��6L   $��	10,26,0,0q�6X   $	��Top=�6k   $	��133��6�   �� 5   
   $��Pocetak akcije:��6   $
��Left=�6*   $��32��6E   $��	10,18,0,0q�6Q   $��2��6d   $	��Top=�6q   $	��133��6�   �� 5   
   $��Kraj akcije:��6   $
��Left=�6'   $��31��6B   $��	10,10,0,0q�6N   $��3��6a   $	��Top=�6n   $	��132��6�   �� 5   
   $��Izadji��6   $
��Left=�6"   $��33��6=   $��	10,21,0,0q�6I   $��4��6\   $	��Top=�6i   $��93��6�    �� IsCancel .  J� RenderTransformOrigin$ 1.419,0.818&�6�   $��1��6�   �� 5   
   -   5        $��Sacuvaj��5      $��1��6#   $
��Left=�63   $��33��6N   $��
149,21,0,0q�6Z   $��4��6n   $	��Top=�6{   $��93��6�   $ -0.075,0.697&�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��	dpPocetak��5   %   $��1��6   $
��Left=�6b   $��31��6}   $��	10,18,0,0q�6�   $��2��6�   $	��Top=�6�   $	��153��6�      SelectedDate 66   ��  �� Path$ PocetakAkcije�6�   �� 5   
   -   5        $��tbPopust��5   "   $��1��6   $
��Left=�6P   $��31��6k   $��	10,10,0,0q�6w   $��1��6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��153��6�   ��62   �� $ Popust�6�     5   
   -   5        $��dpKraj��5   %   $��1��6   $
��Left=�6a   $��31��6|   $��	10,10,0,0q�6�   $��3��6�   $	��Top=�6�   $	��153��6�    63   �� $ ZavrsetakAkcije�6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��	dgNAkcija��5      $��167,26,100,16q�6$   	   CanUserAddRows	 .  
   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 * 6R   $��2��6�    �� SelectedItem 6b   �� $ NamjestajNaAkciji�6�   �� 5    
   -   5         ��Name$ 
btnPreuzmi��5       $��Preuzmi��6%   $
��Left=�67   $��37��6R   $��
226,26,0,0q�6^   $	��Top=�6r   $��86��6�   $��1��6�   5"      5#      