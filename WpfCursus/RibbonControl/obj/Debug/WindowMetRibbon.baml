   M S B A M L   `   `   `  ����H  DRibbonControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WindowMetRibbonControlWindowMetRibbonControl  5   	   ,    &WindowMetRibbonControl.WindowMetRibbon   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6local$clr-namespace:WindowMetRibbonControl     5   	   -   5        $	��350��5      $	��525��6     � Icon$  images\app48.png��6!    � Title$ Window met Ribbon��69    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$
 Help��5      6B     5	   
   -   5        $	 New��5	      6@     5
   
   -   5        $
 Open��5
      6B     5   
   -   5        $
 Save��5      6B     5   
   -   5        $ Close��5      6D     5   
   -   5        $ Print��5      6D     5   
   -   5        $ PrintPreview��5      6M    � 	Resources 5         LogischNaarVisueel0   *WindowMetRibbonControl.BooleanToFontWeight  LogischNaarFontDikte/   )WindowMetRibbonControl.BooleanToFontStyle  LogischNaarFontStijl��%W   &	        &	      &	 &     �� 5   
   6'     5   
   6$     5   
   6#   5      .��5      ]� ��. .+�5   
   +  %System.Windows.Controls.Ribbon.Ribbon  $	��Top=�6      HelpPaneContent 5      1  +System.Windows.Controls.Ribbon.RibbonButton  5         SmallImageSource$ Images\help64.png��6   $
��Help��6D      ToolTipTitle$
 Help��5         ToolTipDescription$ Opent het helpscherm��5      	   ToolTipFooterTitle$	 	More Help��5       
   ToolTipFooterDescription$
 
Druk op F1��5!         ToolTipFooterImageSource$ images\question16.png��5"         ToolTipImageSource$ images\help64.png��5#      5$         QuickAccessToolBar 5'      =  7System.Windows.Controls.Ribbon.RibbonQuickAccessToolBar  5(      -	   5        $	��Qat��5(   7   $��24��6+   .@�5)      6  0System.Windows.Controls.Ribbon.RibbonSplitButton  5  /System.Windows.Controls.Ribbon.RibbonMenuButton   SmallImageSource$ Images\refresh16.png��6(   .@�5*        $ Images\undo16.png��6'   $
��Undo��6L      Label$
 Undo��6[   6j     5+      $ Images\redo16.png��6'   $
��Redo��6L   $
 Redo��6[   6j   5,      7	  1System.Windows.Controls.Ribbon.RibbonToggleButton	  5-      -
   5        $��	ButtonVet��5-   )    	  SmallImageSource$ Images\bold.png��6:   5.      	  5/      -   5        $��ButtonSchuin��5/   )   $ Images\italic.png��6=   50      51         ApplicationMenu 55      :
  4System.Windows.Controls.Ribbon.RibbonApplicationMenu
  56      $ images\bestand64.png��6(      KeyTip$ A��6P   .@�57      >  8System.Windows.Controls.Ribbon.RibbonApplicationMenuItem  $	��New��60    m� Command$	 New��6=   3  -System.Windows.Controls.Ribbon.RibbonMenuItem   ImageSource$ images\new16.png��6K   6l     58      $
��Open��60   $
 Open��6>   $ images\open16.png��6M   6o     59      $
��Save��60   $
 Save��6>   $ images\save16.png��6M   6o   4  .System.Windows.Controls.Ribbon.RibbonSeparator  5:      6(   C  =System.Windows.Controls.Ribbon.RibbonApplicationSplitMenuItem  5;      $��Afdrukmogelijkheden��65   $ images\printer64.png��6R   .@�5<        $��	Afdrukken��64   $ Print��6G   $ images\printer64.png��6W   6|     5=      $��Afdrukvoorbeeld��64   $ PrintPreview��6M   $ images\preview64.png��6d   $   QuickAccessToolBarImageSource$ images\preview64.png��6�   6�   5>       
  FooterPaneContent 5B        5C      $��Close��6'   $ images\close64.png��67   $��Right=�6]   $ 	Afsluiten��6y   6�    
  AuxiliaryPaneContent 5G      2  ,System.Windows.Controls.Ribbon.RibbonGallery  5H      -   5        $��
MRUGallery��5H   (      CanUserFilter .  $
��Auto=�5I   (   .@�5K      :  4System.Windows.Controls.Ribbon.RibbonGalleryCategory  -   5        $��MRUGalleryCat��5K   4   $��Recent Documents��6I   5L      5N      .@�5Q      .  (System.Windows.Controls.Ribbon.RibbonTab  $��Bestand��6      KeyTip$ B��6)   .@�5R      0  *System.Windows.Controls.Ribbon.RibbonGroup  $��	Open/Save��6   .@�5S           LargeImageSource$ images\bestand64.png��6'      Label$ Bestand��6O   $ B��6_   .@�5T        $
 Open��6)   $ images\open16.png��68   $
��Open��6X      KeyTip$ O��6f   6s     5U      $
 Save��6)   $ images\save16.png��68   $
��Save��6X   $ S��6f   6s   5V      5W      5X        5Y      $
��Edit��6   $ E��6&   .@�5Z        $��Bewerken��6   .@�5[        $
 Undo��6%   $ images\undo16.png��64   $
��Undo��6T   6d     5\      $
 Redo��6%   $ images\redo16.png��64   $
��Redo��6T   6d   5]        5^      $��Opmaak��6   .@�5_      3  -System.Windows.Controls.Ribbon.RibbonCheckBox     SmallImageSource$ images\bold.png��6%      Label$	 Vet��6H    d� 	IsChecked 6U   ��   �� ElementName$  	ButtonVet��! �� Path$! 	IsChecked�5`        5a      $ images\italic.png��6%   $ Schuin��6J    6Y   �� $  ButtonSchuin��$! 	IsChecked�5b        5c      -   5        $��CheckBoxAlleenLezen��5c   %   $ images\ReadOnly16.png��6@   $ Alleen lezen��6i   5d      5e        5f      $��Kleur��6   .@�5g        -   5        $��	MenuKleur��5g   '   $ images\kleur64.png��68   $ Letterkleur��6^   .@�5h      6  0System.Windows.Controls.Ribbon.RibbonRadioButton  -   5        "   SmallImageSource$" images\black48.png��5h   @   #   Label$# Zwart��6f   $
 TrueY�6t   
$ � Tag$$ 	#FF000000��6�   6�     5i      -   5        $" images\red48.png��5i   @   $
# Rood��6d   $$ 	#FFFF0000��6q   6�     5j      -   5        $" images\blue48.png��5j   @   $# Blauw��6e   $$ 	#FF0000FF��6s   6�     5k      -   5        $" images\green48.png��5k   @   $# Groen��6f   $$ 	#FF00FF00��6t   6�   5l      5m      5n        5s      $��Nieuw��6   %   ContextualTabGroupHeader$% TabNieuw��6'   .@�5t        .@�5u        $	 New��6%   $ images\New16.png��63   $��Leeg document��6R   6k   5v      5w      &   ContextualTabGroups& 5x      =  7System.Windows.Controls.Ribbon.RibbonContextualTabGroup  5y      '   Header$' TabNieuw��5z      
��� � �y�5{      �� $  TextBoxVoorbeeld��$! 
IsReadOnly�( �� 	Converter#( [  5|      5      �� 5�   
   -   5        $��TextBoxVoorbeeld��5�      $��Dit is voorbeeldtekst��6+   $��Stretch=�5�      $��Stretch=�6(   $��24(�5�      ) �� TextWrapping$
) Wrap=�6   $	��600��6.   $	��900��6=   * �� 
IsReadOnly* 5�      �� $  CheckBoxAlleenLezen��$! 	IsChecked���5�      �� $  	ButtonVet��$! 	IsChecked�#( [ ��5�      �� $  ButtonSchuin��$! 	IsChecked�#( [ .��5�   C   5�      5�      5�      