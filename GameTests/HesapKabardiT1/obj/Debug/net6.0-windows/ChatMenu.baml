   M S B A M L   `   `   `  ����I  EHesapKabardiT1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:HesapKabardiT1HesapKabardiT1  5   	       HesapKabardiT1.ChatMenu   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:HesapKabardiT1     5   	   -   5          � ShowInTaskbar$  False��5   	   $��False��5   	    � Topmost$
 True��5
   	    � 
ResizeMode$ NoResize=�5   	    � Title$ 	Chat Room��5   	   $	��550��5   	   $	��400��6   ���#151515
�������.��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6   .+�5   
   � $��0��6   .+�5      �� -   5         ��Name$ RoomNameLabel��5      
�������$��	Room Name��6>   $��Center=�6R   $��18(�6v   6�   5      � 5   
   $��1��6   .+�5      �� -   5         ��Name$ messageScroll��5   >   $
��Auto=�6   .��5      �� -   5         ��Name$ messageHolder��5   4    �� Orientation$ Vertical=�6   5"      5#      5$      � 5%   
   $��2��6   ���#202020	 � ColumnDefinitions	 5&      �� 5'      $��* �6#   �� 5(      $��50 �6#   .+�5*      �� -   5        
 ��Name$
 MessageContent��5*   `   $��5q�6    �� MaxLines$ 5��6"    �� 	MaxLength$	 256��6/   $��0��6x   
������ 
�������$��0q�6�    �� TextWrapping$
 Wrap=�6�   $��50��6�   $��18(�6�    �� 
CaretBrush
 �����6�   �� 5+      -   5         ��Name$ SendMessageBtn��5+   @      DarkThemedButton#���   6   $��1��6u   
������ $��0q�6�   
�������$	��△��6�   $��25(�6�   6�   5,      5-      5.      