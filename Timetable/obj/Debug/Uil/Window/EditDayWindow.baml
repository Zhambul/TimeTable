   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.1.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      D @Timetable, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Timetable.BllTimetable.Bll 5      =#clr-namespace:Timetable.Bll.LessonsTimetable.Bll.Lessons 5      (   "Timetable.Uil.Window.EditDayWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Pcontrols;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      +bllclr-namespace:Timetable.Bll     5      7lessons#clr-namespace:Timetable.Bll.Lessons     5        � Title$  Изменить день��5      $	��450��5      $	��600��5	      $��0q�5
      (   "MahApps.Metro.Controls.MetroWindow   	GlowBrush$ Black��5       � 
ResizeMode$ CanResizeWithGrip=�5         WindowTransitionsEnabled .   � WindowStartupLocation$ CenterScreen=�5      .��5      �  � RowDefinitions 5   
   �� 5      $	��10* �6   �� 5      $��1* �6   .+�5   
   �� $��0��6   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��
MyDataGrid��5      $��
10,20,10,0q�5      $��Stretch=�5         CanUserAddRows .     CanUserResizeRows .     CanUserSortColumns .  	   EnableRowVirtualization	 .  
   CanUserResizeColumns
 .     MinColumnWidth$	 100Q�5         AutoGenerateColumns .     AzureDataGrid#��[  5!      ��5   *   ��  �� Path$ 
ResultDays�   Columns 5#      4  .System.Windows.Controls.DataGridTemplateColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$ День��6)      CellTemplate 5%      �� 5&       �� DataType$ bll:Day��6+   .R�5'   "   �� $��Center=�6H   $��3,3,3,3q�6c   ��6,   �� $
 Date�6c   5(      5*        5,      $ Предмет��6)    5-      �� 5.      $ bll:Day��6'   .R�5/      �� ��6'   �� *ListOfLessons+��50   "   �� 51   &   $ lessons:Lesson��63   .R�52   *   �� .+�53   .   �� $��Center=�54   8   $��40��55   8   ��53   6   �� *Name+55   8   �� 56   .   
���   � �� Stretch$
 Fill=�6B   	 �� X2$ 1��6Q   $��Center=�6X   57   +   58   '   5:      5;      5=        5?      $ 
Время��6)    5@      �� 5A      $ bll:Day��6'   .R�5B      �� ��6'   �� *ListOfLessons+��5C   "   �� 5D   &   $ lessons:Lesson��63   .R�5E   *   �� .+�5F   .   �� $��Center=�67   $��40��6o   ��6T   �� *	StartTime+6o   �� 5G   .   
���   �$
 Fill=�6B   $ 1��6Q   $��Center=�6X   5H   +   5I   '   5K      5L      5N        5P      $  Преподователь��6)    5Q      �� 5R      $ bll:Day��6'   .R�5S      �� ��6'   �� *ListOfLessons+��5T   "   �� 5U   &   $ lessons:Lesson��63   .R�5V   *   �� .+�5W   .   �� $��Center=�67   $��40��6m   ��6T   �� *	Teacher+6m   �� 5X   .   
���   �$
 Fill=�6B   $ 1��6Q   $��Center=�6X   5Y   +   5Z   '   5\      5]      5_        5a      $ Аудитория��6)    5b      �� 5c      $ bll:Day��6'   .R�5d      �� ��6'   �� *ListOfLessons+��5e   "   �� 5f   &   $ lessons:Lesson��63   .R�5g   *   �� .+�5h   .   �� $��Center=�67   $��40��6o   ��6T   �� *	Classroom+6o   �� 5i   .   
���   �$
 Fill=�6B   $ 1��6Q   $��Center=�6X   5j   +   5k   '   5m      5n      5p      5s      �� 5t   
   -   5        $%��Добавить занятие��5t      6L   �� 5u   
   -   5        $
��Ок��5u      69   5v   	   5w      5z      