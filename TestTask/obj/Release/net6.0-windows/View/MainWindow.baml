   M S B A M L   `   `   `  ���� C  ?TestTask, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:TestTaskTestTask  7 clr-namespace:TestTask.ViewModelTestTask.ViewModel      TestTask.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     (localclr-namespace:TestTask     /vm clr-namespace:TestTask.ViewModel       � Title$  Steps��$	��720��$
��1280��.���  � RowDefinitions �� $��25 ���  � ColumnDefinitions �� .+�o� $��0��$��25��$	��Top=�.@�m� $
��File��.@�m� -   $��	Save File��m� -   $��Save File as���� m� -   $
��Exit���� $��1�� �� Orientation$ 
Horizontal=� � DataContext   TestTask.ViewModel.Main  .+��� -   $��userList��$	��648������ *User+ �� SelectedItem �� *SelectedUser+ �� View �� P��� $
��Name�� �� Width$	 300�� �� CellTemplate �� .R��� $��14(�$	��300������ 	 �� Path$
	 Name����� $	 Color��� $��Average of steps��$ 50�� �� .R��� $��14(�$��50������ $	 AverageOfSteps����� $	 Color��� $��Best result��$ 50�� �� .R��� $��14(�$��50������ $	 MaxSteps����� $	 Color��� $��Worst result��$ 50�� �� .R��� $��14(�$��50������ $	 MinSteps����� $	 Color���  "  TestTask.ViewModel.DrawGraph  .+��� $��14(�
 �� TextAlignment$
 Center=�$��
User Graph��F� $��3��
��� ���
����ح����� *Graph+�� $
 Right=����� $	 TextDays�