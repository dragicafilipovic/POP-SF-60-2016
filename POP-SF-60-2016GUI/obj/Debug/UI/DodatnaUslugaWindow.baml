   M S B A M L   `   `   `  ����L  HPOP-SF-60-2016GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:POP_SF_60_2016GUI.UIPOP_SF_60_2016GUI.UI  5   	   .    (POP_SF_60_2016GUI.UI.DodatnaUslugaWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:POP_SF_60_2016GUI.UI     5   	     � Title$  DodatnaUslugaWindow��5   	   $	��500��6%   $	��900��62   ���	#FF374D35 � 
ResizeMode$ NoResize=�6U   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��430* �6   �� 5      $
��109* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dgUsluga��5   .   $��0��6   $��20(�6    $��
10,74,10,0q�6>      CanUserAddRows .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6i   6y   �� 5   
   -   5        $��1��5      $��Dodaj��6   $��26,30,771,29q�6.   6D   �� 5   
   -   5        $��1��5      $��Izmjeni��6   $��159,30,638,29q�60   6G   �� 5   
   -   5        $��1��5      $��Obrisi��6   $��292,30,505,29q�6/   6F   �� 5   
   -   5        $��1��5      $��Zatvori��6   $��772,30,25,29q�60   6F   �� 5   
   -   5        $��
tbPretraga��5   9   $
��Left=�6   $��30��6-   $��	10,21,0,0q�6K    �� TextWrapping$
 Wrap=�6^   $	��Top=�6r   $	��190��6�   �� 5   
   -   5        $��btnPretraga��5   ?   $��Pretraga��6   $
��Left=�6$   $��30��6R   $��
215,21,0,0q�6^   $	��Top=�6r   $��80��6�   6�   �� 5   
   $��Sortiranje: ��6   $
��Left=�6'   $��30��6B   $��
562,21,0,0q�6N   $	��Top=�6b   $��92��6z   �� 5   
   -   5        $��cbSort��5   .   $
��Left=�6   $��30��6<   $��
659,21,0,0q�6H   $	��Top=�6\   $	��190��6t   6�   5      5      