   M S B A M L   `   `   `  ����  SystemMonitorApp!    SystemMonitorApp.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  System Monitor��5   	   $	��500��6    $	��900��6-   .��5
      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $��* �6#   .+�5      �� -   5        $��0��5      $	��150��5      $��0 0 10 0q�5      ��5      �� 5       �� 
TargetType" ��6   .�5       ��  �� Property � �� �� Value$ Start��64   �� 5!       � ��
 ����67   �� 5"       � ��
 �   �67    �� Triggers 5#      �� 5$       �� Binding 6*   �� *	IsRunning+ �� Value True6H   .a�5%   "   ��  � ��$
 Stop��6<   �� 5&   "    � ��
 �\\��6?   �� 5'   "    � ��
 �����6?   5(      5*      5,      �� 5.      $��1��6   $��Center=�5/      $��Intervalo (ms):��50      $��0 0 10 0q�51      � 54      $��2��6    55      �� 56      $��* �6'   �� 57      $
��Auto �6'   .+�5:      �� $��0��6   	 � Minimum$		 500Q�5;      
 � Maximum$
 10000Q�5<       �� TickFrequency$	 500Q�5>       �� IsSnapToTickEnabled$
 True��5?      $��0,0,10,0q�5@       � Value 5=      �� *
Interval+ �� Mode$ TwoWay=�5@      �� 5B      $��1��6   $��Center=�5C      $
��Bold"�5E      $��60��5F       �� TextAlignment$ Right=�5G      ��5D      �� *
Interval+5G      5H      5I      &   System.Windows.Controls.DataGrid  5L   
   $��2��6      AutoGenerateColumns$
 True��5N         CanUserAddRows$ False��5O         
IsReadOnly$
 True��5P      $��Stretch=�5Q      $��Stretch=�5R      ��5M      �� *	Samples+5R      5S      5T      