   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	    	MVVMHobby#   MVVMHobby.View.HobbyLijstView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   b ^GalaSoft.MvvmLight.Platform, Version=5.4.1.0, Culture=neutral, PublicKeyToken=5f873c45e98af8a1+gala http://www.galasoft.ch/mvvmlight  5   	     � Title$  HobbyLijstView��5   	   $	��300��6    $	��600��6-   .��5      � -   5        $��
LayoutRoot��5      
������  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ Vertical=�6   .+�5   
   �� -   5        $��ListBoxHobbies��5      $��Center=�6(   $	��250��5      $	��220��6    �� DisplayMemberPath$ 
Activiteit��5      ��5      �� *
HobbyLijst+ �� SelectedItem 5      �� *SelectedHobby+�� 5   
   -   5        $��ButtonVerwijder��5      $��	Verwijder��6(   $��Center=�5      $��10q�6*   $	��250��5      ��5      �� *VerwijderCommand+5      � 5   
   $��1��6   
������  � RowDefinitions 5      �� 5      $��60 �6    �� 5       $��60 �6    �� 5!      $	��100 �6    �� 5"      $��* �6     5$      �� 5%      $��3* �6#   �� 5&      $��5* �6#   .+�5(      �� $��
10,15,0,10q�6   $
��Left=�6(   $��Center=�5)      $��
Categorie:��6/   $��32��6D   $��80��6P   �� 5*      $��
10,15,0,10q�6   $��1��6(   $
��Left=�65   $��Center=�5+      $��Activiteit:��6/   $��28��6E   $��80��6Q   �� 5,      $��
10,30,0,40q�6   $��2��6(   $
��Left=�65   $��Center=�5-      $��Symbool:��6/   $��28��6B   $��80��6N   �� 5.      $��1��6    �� TextWrapping$
 Wrap=�6&   $��Center=�6:   $��10,15q�5/      $��24��6%   ��50      �� *SelectedHobby.Categorie+�� 51      $��1��6   $
 Wrap=�6&   $��1��6:   $��Center=�52      $��10,15q�61   $��24��6@   ��53      �� *SelectedHobby.Activiteit+ �� UpdateSourceTrigger$ PropertyChanged=��� 55      $��1��6   $��2��6$   $��10q�61   ��6=   �� *SelectedHobby.Symbool+.   (System.Windows.Interactivity.Interaction   Triggers 56      /   )System.Windows.Interactivity.EventTrigger  57      	   	EventName$	 	MouseDown��6%   .   (System.Windows.Interactivity.TriggerBase
   Actions.
 58      /  )GalaSoft.MvvmLight.Command.EventToCommand     PassEventArgsToCommand .    Command 6.   �� *MouseDownCommand+6S   59        5:      $	 MouseUp��6%   .
 5;         .  6.   �� *MouseUpCommand+6Q   5<      5>      5?      5@      5A      