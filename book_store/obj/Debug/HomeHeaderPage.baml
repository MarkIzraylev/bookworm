   M S B A M L   `   `   `  ����E  Abook_store, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:book_store
book_store  5          book_store.HomeHeaderPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:book_store     5        N� Title$0  *Шапка главной страницы��5	      .��5      � -   5         �Name$ Header��5       � RowDefinitions 5   
   �� 5      6    � ColumnDefinitions 5   
   �� 5      $
��267* �6   6.   �� 5      $
��Auto �6   6.   �� 5      $
��266* �6   6.   .+�5   
   �� $��0��6   $��0��6%    �� Orientation$ 
Horizontal=�62   $��Stretch=�6K   $��Center=�6i   .+�5      �� $
��Left=�6   $��27��6/   $��15,10,10,10q�6;   $��Center=�6P   $��27��6k   $��book_stack.png��6v    � Cursor$ 	ScrollAll��6�   �� 5      -   5         ��Name$ CompanyName��5      $��bookworm��6)   $��Center=�6<   $��Center=�6W   $��Georgia)�6y   $
��Bold"�6�   $��14(�6�   ���	#FF472E5D$
 Hand��6�   5      �� 5   
   $��1��6   $��0��6%   $ 
Horizontal=�62   $��Center=�6K   $��Center=�6h   .+�5       � -   5          �Name$ NavBar��5        � NavigationUIVisibility$ Hidden=�6$   5      �� 5   
   $��2��6   $��0��6%   $ 
Horizontal=�62   $��Right=�6K   $��Center=�6g   .+�5      �� -   5        	 ��Name$	 SignIn��5      $��0,0,20,0q�6%   $��2��67   $��0��6G      RoundButton#���   6T   $��
войти��6z   $��49��6�   ���	#FF2B241F���	#FF2B241F$��Georgia)�6�   $��24��6�   ��6�   Z� 6�   �� 5      -   5        $��0,0,10,0q�5      $��2��6'   $��0��67   #���   6D   $	����6j   $��Segoe MDL2 Assets)�6}   ���	#FF2B241F$��0q�6�   $	��6,0q�6�   ��6�   Z� 6�   �� 5      -   5        $��0,0,10,0q�5      $��2��6'   $��0��67   $��Segoe MDL2 Assets)�6D   ���	#FF2B241F$��0q�6z   $	��6,0q�6�   ��6�   Z� ��5      �� 5       
 �� 
TargetType"
 ��6   .�5!      ��  �� Property � �� �� Value$	 ��6;    �� Triggers 5"      �� 5#       �� Binding 6*   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" � �� Path$ WindowState� �� Value 	Maximized6�   .a�5$   "   ��  � ��$	 ��6C   5%      5'      5)      �� 5*      -   5        $��0,0,10,0q�5*      $��2��6'   $��0��67   #���   6D   $	����6j   $��Segoe MDL2 Assets)�6}   ���	#FF2B241F$��0q�6�   $	��6,0q�6�   ��6�   Z� 6�   5-      5/      50      