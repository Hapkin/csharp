   M S B A M L   `   `   `  ����?  ;Bars, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:BarsBars  5   	   clr-namespace:BarsBars  5   	       Bars.BarWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %customclr-namespace:Bars     5   	   $localclr-namespace:Bars     5   	   -   5          � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ Close��5      6E     5   
   -   5        $ PrintPreview��5      6M     5   
   -   5        $ Print��5      6D     5   
   -   5        $
 Open��5      6B     5   
   -   5        $
 Save��5      6B     5   
   -   5           Bars.BarWindow   mijnRouteCtrlB# Z 5      6N     5   
   -   5           mijnRouteCtrlI# Z 5      6N    J� InputBindings 5      �� 5   
   
 �� Key$ B��6    �� 	Modifiers$ Controlf�6    �� Command# Z 61   �� 5   
   $ I��6   $ Controlf�6   # Z 61   .��5       ]� .+�5!   
   o� -	   5        $��MenuBalk��5!      $��24��6   $	��Top=�6+   .@�5"      m� $��_Bestand��6   .@�5#      m� $��Openen��6   	 m� Command$
	 Open��6+   6<   m� 5$      $��Opslaan��6   $
	 Save��6,   6=   m� 5%      $��Afdrukvoorbeeld��6   $	 PrintPreview��64   6M   m� 5&      $��Afdrukken...��6   $	 Print��61   6C   �� 5'      6   m� 5(      $��	Afsluiten��6   $	 Close��6.   6@   5)      m� 5*      $��Editeren��6   .@�5+      m� $��Knippen��6   $		 Cut��6,   6<   m� 5,      $��	Kopiëren��6   $
	 Copy��6-   6>   m� 5-      $��Plakken��6   $	 Paste��6,   6>   5.      m� 5/      $��
Lettertype��6   .@�50      m� -
   5        $��Fontjes��50      $
��Font��6*   .@�51      m� -   5        $��Courier��51      $��Courier New��6.   
 m� IsCheckable
 . 6q   m� 52      -   5        $��Arial��52      $��Arial��6,   
 . 6i   m� 53      -   5        $��Comic��53      $��Comic Sans MS��6,   
 . 6q   54      m� 55      -   5        $��MenuVet��55      $��Vetdruk��6*   
 .  m� InputGestureText$ Ctrl+B��6d   6�   m� 56      -   5        $��
MenuSchuin��56      $��
Schuindruk��6-   
 . $ Ctrl+I��6m   6�   57      58      `� 5;   
   $	��Top=�6   .�5<      c� -   5        $��BestandBalk��5<      .@�5=      �� $��Close��6   .��5>      �� $��images/afsluiten.png��6   6<   5?      �� 5@      $
��Open��6   .��5A      �� $��images/open.png��6   67   5B      �� 5C      $
��Save��6   .��5D      �� $��images/save.png��6   67   5E      �� 5F      $��PrintPreview��6   .��5G      �� $��images/preview.png��6   6:   5H      �� 5I      $��Print��6   .��5J      �� $��images/print.png��6   68   5K      5L      c� 5N      -   5        $��EditeerBalk��5N      .@�5O      �� $	��Cut��6   .��5P      �� $��images/cut.png��6   66   5Q      �� 5R      $
��Copy��6   .��5S      �� $��images/copy.png��6   67   5T      �� 5U      $��Paste��6   .��5V      �� $��images/paste.png��6   68   5W      5X      c� 5Y      -   5        $��LettertypeBalk��5Y      .@�5Z      d� -   5        $��	ButtonVet��5Z      .��5[      �� $��images/bold.png��6   67   5\      d� 5]      -   5        $��ButtonSchuin��5]      .��5^      �� $��images/italic.png��6   69   5_      �� 5`      -   5        $��LettertypeComboBox��5`   R   $	��150��6l   ��6x   ��    System.Windows.Media.Fonts   SystemFontFamilies �� Source# Z ��5a      �� 5b      .R�5c      �� ��6(   �� ��6?   �� 5d      5f      5g      5h      �� 5k   
   $��Bottom=�6   $��24��6,   .@�5l      �� -   5        $��	StatusVet��5l      $��Right=�6-   $��50��6D   $��Right=�6O   $	��Vet��6r   ��6�   ��  �� ElementName$ TextBoxVoorbeeld�� �� Path$ 
FontWeight�6�   �� 5m      -   5        $��StatusSchuin��5m      $��Right=�60   $��50��6G   $��Right=�6R   $��Schuin��6u   ��6�   �� $ TextBoxVoorbeeld��$ 	FontStyle�6�   �� 5n      -   5        $��StatusLettertype��5n      ��64   �� $ LettertypeComboBox��$ SelectedValue�5o      5p      �� 5q   
   -   5        $��TextBoxVoorbeeld��5q      $��Dit is voorbeeldtekst��6*   $��Stretch=�6G   $��Stretch=�6c   $��24(�6�    �� TextWrapping$
 Wrap=�6�   $	��600��6�   $	��900��6�   ��6�   �� $ LettertypeComboBox��$ SelectedValue�.��6  5s      5u      5w      