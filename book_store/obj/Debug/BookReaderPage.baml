   M S B A M L   `   `   `  ����E  Abook_store, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:book_store
book_store  5          book_store.BookReaderPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:book_store     5        N� Title$  BookReaderPage��5	       N� 
FontFamily$ Georgia)�5
      .��5      � $��30q�6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ bookTextBlock��5   !   $��0��6   $
��Wrap=�68   � 5   
   $��1��6   $��Stretch=�6    � ColumnDefinitions 5      �� 5      $��* �6#   6/   �� 5      $��* �6#   6/   �� 5      $��* �6#   6/   .+�5      �� -   5         ��Name$ FontSizeComboBox��5   '   $��0��6   $��0,0,5,0q�6A   $
��Left=�6�   .@�5      �� 
 � Tag$ 12��6   $
��12px��6(   $��12(�67   6G   �� 5      $ 14��6   $
��14px��6(   $��14(�67   6G   �� 5      $ 16��6   $
��16px��6(   $��16(�67   6G   �� 5      $ 18��6   $
��18px��6(   $��18(�67   6G   �� 5      $ 20��6   $
��20px��6(   $��20(�67   6G   �� 5      $ 22��6   $
��22px��6(   $��22(�67   6G   5       �� 5!      $��1��6    �� Orientation$ 
Horizontal=�6)   $��Center=�6B   .+�5"      �� -   5         ��Name$ 
prevButton��5"      $��Предыдущая��6-   $��0,0,5,0q�6[      RoundButton#���   6l   $	��5,3q�6�   ���	#FF2B241F���	#FF2B241F��6�   Z� �� 5#      -   5        	 ��Name$	 currPage��5#      $��1��6*   $��0,0,5,0q�66   �� 5$      -   5        $ 
nextButton��5$      $��Следующая��6-   #���   6Z   $	��5,3q�6�   ���	#FF2B241F���	#FF2B241F��6�   Z� 5%      �� 5&      -   5        $ FontColorComboBox��5&   '   $��2��6   $��0,0,5,0q�6B   $��Right=�6�   .@�5'      �� $ FF2B241F��6   ���	#FF2B241F$��Тёмный��6E   6X   �� 5(      $ FF472E5D��6   ���	#FF472E5D$��Фиолетовый��6E   6\   �� 5)      $ FF645549��6   ���	#FF645549$��Светлый��6E   6Y   5*      5+      5-      5.      