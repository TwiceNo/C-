   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5   	       WpfApp2.ItemChange   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp2     5   	   -   5          � Title$/  )Корректировка таблицы��5   	   $	��350��6'   $	��330��64    � 	Resources 5         FocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray   OptionMark.Static.Background �� Color  OptionMark.Static.Border  OptionMarkFocusVisual �� 
TargetType �� 
TargetType	 �� CornerRadius
 �� Triggers P� Property P� Value # OptionMark.MouseOver.Background  OptionMark.MouseOver.Border  OptionMark.MouseOver.Glyph " OptionMark.Disabled.Background  OptionMark.Disabled.Border 	 OptionMark.Disabled.Glyph !
 OptionMark.Pressed.Background  OptionMark.Pressed.Border  OptionMark.Pressed.Glyph  OptionMark.Static.Glyph  CheckBoxStyle1��%�  &	        &	 �     &	 �     &	 �     '�� �    &	 �    &	 �    &	     &	 /    &	 R    &		 u    &	
 �    &	 �    &	 �    &	     &	 $    7   7  7  �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$    . #��� ��6J   $��1��6�   $	 1 2R�6�   5      5      5      �� 5   
   $ 	#FFFFFFFF��6?   �� 5   
   $ 	#FF373E40��6;   �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��15,0,0,0q�6$    . #��� ��6Q   $��1��6�   $	 1 2R�6�   5      5      5      �� 5!   
   " ��6   .�5"      ��  � �� �#373E406+   �� 5#       � ��$ Segoe UI)�6+   �� 5$       � ��$ 16(�6)   �� 5%       � ��$ Center=�64   �� 5&       � ��$ Center=�62   �� 5'       � ��$ Light"�6+   �� 5(       � ��
 ���� 6+   �� 5*       � �� 5+      �� 5-      " ��6&   .R�5/      �� #��z��6!   $	 5��50      $��1q�51      ���#373E40._�54      �� $��Center=�6/   $��Center=�6L   56      58      5<      
 5>      P� 5@       �@J�IsMouseOver . . �5A      ��  � �� �#F3F7F063   �� 5B       � �� �#6B888063   �� 5C       � �� �#6B888064   5D      P� 5F       � {� .  . �5G      ��  � �� �#4F565663   5H      5M      �� 5O   
   $ 	#FFF3F9FF��6B   �� 5P   
   $ 	#FF5593FF��6>   �� 5Q   
   $ 	#FF212121��6=   �� 5R   
   $ 	#FFE6E6E6��6A   �� 5S   
   $ 	#FFBCBCBC��6=   �� 5T   
   $ 	#FF707070��6<   �� 5U   
   $ 	#FFD9ECFF��6@   �� 5V   
   $ 	#FF3C77DD��6<   �� 5W   
   $ 	#FF212121��6;   �� 5X   
   $ 	#FF212121��6:   �� 5Y   
   " ��6'   .�5Z      ��  �@�FocusVisualStyle8   61   �� 5[       � ��8  6+   �� 5\       � ��8  6,   �� 5]       � ��# � ��6+   �� 5^       � ��$ 1q�60   5_      5`      .��5b      �  � RowDefinitions 5c   
   �� 5d      $��8* �6   �� 5e      $��2* �6   .+�5g   
   ��  �� Orientation$ Vertical=�6   $��0��6,   .+�5h      �� .+�5i      �� $��Сотрудник:��5j      $��16(�5k      $��Center=�5l      $��Center=�5m      $��10q�5n      5o      �� 5q      $ 
Horizontal=�6   $��Center=�62   .+�5r      �� $	��120��5s      $��Фамилия��5t      $��17q�5u      $��14(�5v      $��Center=�5w      �� 5x      -   5         ��Name$ surname��5{      $��30��5y      $	��150��5z      $��14(�5|      $��Center=�5}      $��Center=�5~      5�      5�      �� 5�      $ 
Horizontal=�6   $��Center=�62   .+�5�      �� $	��120��5�      $��Имя��5�      $��17q�5�      $��14(�5�      $��Center=�5�      �� 5�      -   5        $
 name��5�      $��30��5�      $	��150��5�      $��14(�5�      $��Center=�5�      $��Center=�5�      5�      5�      �� 5�      $ 
Horizontal=�6   $��Center=�62   .+�5�      �� $	��120��5�      $��Отчество��5�      $��17q�5�      $��14(�5�      $��Center=�5�      �� 5�      -   5        $ 
patronymic��5�      $��30��5�      $	��150��5�      $��14(�5�      $��Center=�5�      $��Center=�5�      5�      5�      �� 5�      $ 
Horizontal=�6   $��Center=�62   .+�5�      �� $	��120��5�      $��Номер кассы��5�      $��17q�5�      $��14(�5�      $��Center=�5�      �� 5�      -   5        $ twind��5�      $��30��5�      $	��150��5�      $��14(�5�      $��Center=�5�      $��Center=�5�      5�      5�      5�      �� 5�   
   $��1��6   $ 
Horizontal=�6"   $��Center=�5�      $��Center=�5�      .+�5�      �� -   5         ��Name$ cancel��5�      $��14(�5�      $��30��5�      $	��120��5�      $��Отмена��5�      $��20, 10, 20, 10q�5�      5�      �� 5�      -   5        $ confirm��5�      $��14(�5�      $��30��5�      $	��120��5�      $��Подтвердить��5�      $��20, 10, 20, 10q�5�      5�      5�      5�      5�      