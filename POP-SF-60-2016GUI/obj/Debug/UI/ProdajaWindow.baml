   M S B A M L   `   `   `  ����L  HPOP-SF-60-2016GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:POP_SF_60_2016GUI.UIPOP_SF_60_2016GUI.UI  5   	   (    "POP_SF_60_2016GUI.UI.ProdajaWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:POP_SF_60_2016GUI.UI     5   	     � Title$  ProdajaWindow��5   	   $	��500��6   $	��900��6,    � 
ResizeMode$ NoResize=�68   ���	#FF374D35.��5	      �  � RowDefinitions 5
   
   �� 5      $
��430* �6   �� 5      $
��109* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��	dgProdaja��5   .   $��0��6   $��20(�6    $��
10,76,10,0q�6?      CanUserAddRows .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6j   6z   �� 5   
   -   5        $��1��5      $��Prodaja��6   $��10,33,789,26q�60   6F   �� 5   
   -   5        $��
btnIzmjena��5   0   $��1��6   $��Izmjena��6   $��151,33,648,26q�6B   6Y   �� 5   
   -   5        $��1��5      $��Prikaz��6   $��302,33,497,26q�6/   6F   �� 5   
   $��Zatvori��6   $��775,33,24,26q�6#    �� IsCancel . $��1��6I   �� 5   
   -   5        $��
tbPretraga��5   -   $
��Left=�6   $��30��6?   $��	10,21,0,0q�6K    �� TextWrapping$
 Wrap=�6^   $	��Top=�6r   $	��190��6�   �� 5   
   -   5        $��btnPretraga��5   $   $��Pretraga��6   $
��Left=�67   $��30��6R   $��
215,21,0,0q�6^   $	��Top=�6r   $��80��6�   �� 5   
   $��Sortiranje: ��6   $
��Left=�6'   $��30��6B   $��
562,21,0,0q�6N   $	��Top=�6b   $��92��6z   �� 5   
   -   5        $��cbSort��5   .   $
��Left=�6   $��30��6<   $��
659,21,0,0q�6H   $	��Top=�6\   $	��190��6t   5      5      