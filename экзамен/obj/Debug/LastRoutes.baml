   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5          WpfApp2.LastRoutes   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WpfApp2     5        N� Title$  
LastRoutes��5	       � 	Resources 5       �� Source�� 5   
   $ PageResources.xaml?�6   %    .��5      � ���#DCE0D9 J� SnapsToDevicePixels . .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$
 grid��5      $��Stretch=�5      $��14(�5      $��Segoe UI)�5      $��Light"�5         CanUserAddRows .     
IsReadOnly .    AutoGenerateColumns .  ��5      ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn	   Header$	 
Время��5!      
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 80 5"      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5#      �� *[0]+  5$      $	 Состав��5%      $
 80 5&       5'      �� *[1]+  5(      $	 Рейс��5)      $	
 100 5*       5+      �� *[2]+  5,      $	 Маршрут��5-      $	
 300 5.       5/      �� *[3]+  50      $	 Статус��51      $	
 105 52       53      �� *[4]+55      57      58      