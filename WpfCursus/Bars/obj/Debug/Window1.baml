   M S B A M L   `   `   `  ����?  ;Bars, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:BarsBars  5   	       Bars.Window1   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #mijnclr-namespace:Bars     5   	     � Title$  Window1��5   	   $	��450��6   $	��800��6&    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Bars.Window1   	mijnRoute   Command# Z 5      6E    J� InputBindings 5      �� 5   
   
 �� Key$ B��6    �� 	Modifiers$ Controlf�6    �� Command# Z 61   .��5      ]� .+�5   
   o� -   5        $��MenuBalk��5      $��24��6   $	��Top=�6+   .@�5      m� $��_Bestand��6   .@�5      m� $��Openen��6    m� Command$
 Open��6+   6<   5      5      `� 5   
   $	��Top=�6   .�5      c� -   5        $��EditeerBalk��5      .@�5      �� $	��Cut��6   .��5      �� $��images/cut.png��6   66   5       5!      5"      �� 5%   
   $��Bottom=�6   $��24��6,   .@�5&      �� -   5        $��	StatusVet��5&      $��Right=�6-   $��50��6D   $��Right=�6O   $	��Vet��6r   ��6�   �� 	 �� ElementName$	 TextBoxVoorbeeld��
 �� Path$
 
FontWeight�5'      5(      �� 5+   
   -   5        $��TextBoxVoorbeeld��5+      $��Dit is voorbeeldtekst��6*   $��Stretch=�6G   $��Stretch=�6c   $��24(�6�    �� TextWrapping$
 Wrap=�6�   $	��600��6�   $	��900��6�   ��6�   �� $	 LettertypeComboBox��$
 SelectedValue�.��6  5,      5.      5/      