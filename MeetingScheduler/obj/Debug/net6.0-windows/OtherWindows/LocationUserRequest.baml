   M S B A M L   `   `   `  ����K  GMeetingScheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:MeetingScheduler.OtherWindowsMeetingScheduler.OtherWindows  5   	   I)clr-namespace:MeetingScheduler.ComponentsMeetingScheduler.Components  5   	   7    1MeetingScheduler.OtherWindows.LocationUserRequest   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:MeetingScheduler.OtherWindows     5   	   @
Components)clr-namespace:MeetingScheduler.Components     5   	     � Title$  LocationUserRequest��5	   	   $	��450��6%   $	��800��62   .��5
      �  � RowDefinitions 5   
   �� 5      �� 5      $��50 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ locationsDataGrid��5      $��0��6.   $��25(�6>      SelectionMode$ Single=�6L      AutoGenerateColumns$ False��6c      CanUserAddRows$ False��6      CanUserReorderColumns$ False��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Nome��6K   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6Y   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� *Name+ �� Mode$ OneWay=�6Y     5      $ Endereco��6N   $	 * 6`   
 6%   �� *	Address+$ OneWay=�6`     5      $ 
Capacidade��6K   $	 * 6_   
 6%   �� *Room+$ OneWay=�6_     5      $
 Sala��6O   $	 * 6]   
 6%   �� *
Capacity+$ OneWay=�6]   5      0   *MeetingScheduler.Components.AddNewLocation  5   
   -   5          Name$ addNewLocationButton��5   $   ${�False��6B   $y�Hidden=�6T   � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��2* �6#   �� 5      $��* �6#   .+�5!      �� -   5         ��Name$ changeButton��5!      $��1��6+   $��5q�6;   $��Adicionar novo local��6F   6e   5"      5#      5$      