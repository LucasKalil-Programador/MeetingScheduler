   M S B A M L   `   `   `  ����K  GMeetingScheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:MeetingScheduler.OtherWindowsMeetingScheduler.OtherWindows  5   	   3    -MeetingScheduler.OtherWindows.TeamUserRequest   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:MeetingScheduler.OtherWindows     5   	     � Title$  TeamUserRequest��5   	   $	��450��6!   $	��800��6.   .��5	      �  � RowDefinitions 5
   
   �� 5      $��50 �6   �� 5      �� 5      $��50 �6    � ColumnDefinitions 5   
   �� 5      �� 5      $��50 �6   �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$  nonSelectedClientsDataGrid��5      $��0��67   $��1��6G   $��25(�6T      SelectionMode$ Extended=�6b      AutoGenerateColumns$ False��6{      CanUserAddRows$ False��6�      CanUserReorderColumns$ False��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$
	 Nome��6K   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Name+ �� Mode$ OneWay=�6Y     5      $	 Cargo��6M   $
 * 6\    6%   �� *Office+$ OneWay=�6\   5        5   
   -   5        $ selectedClientsDataGrid��5      $��2��64   $��1��6D   $��25(�6Q   $ Extended=�6_   $ False��6x   $ False��6�   $ False��6�    5        5      $
	 Nome��6K   $
 * 6Y    6%   �� *Name+$ OneWay=�6Y     5       $	 Cargo��6M   $
 * 6\    6%   �� *Office+$ OneWay=�6\   5"      � 5$   
   $��1��6   $��1��6    5%      �� 5&      �� 5'      $��50 �6    �� 5(      �� 5)      $��50 �6    �� 5*      .+�5-      �� -   5        $��1��5-      $��2q�6"   
������ $��0q�6F   .��5.      �� $%��/ImageResources/right-arrow.png��6   $��5q�6A   5/      �� 51      -   5        $��3��51      $��2q�6"   
������ $��0q�6F   .��52      �� $$��/ImageResources/left-arrow.png��6   $��5q�6@   53      54      �� 55   
   $ ��Usuarios não selecionados��6   �� 56   
   $��Usuarios selecionados��6   $��2��61   � 58   
   $��0��6   $��2��6   $��3��6,    59      �� 5:      �� 5;      �� 5<      .+�5?      �� -   5        $��	Confirmar��5?      $��1��6)   $��5q�69   6D   5@      5B      5C      