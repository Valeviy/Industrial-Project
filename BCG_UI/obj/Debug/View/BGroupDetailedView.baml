   M S B A M L   `   `   `  ����A  =BCG_UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:BCG_UI.ViewBCG_UI.View  5      $    BCG_UI.View.BGroupDetailedView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Be:http://schemas.microsoft.com/expression/2010/interactivity  5      %localclr-namespace:BCG_UI.View  5      .��5
      �   � RowDefinitions  5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      $
��Auto �6   6,    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   6.   �� 5      $
��Auto �6   6.   �� 5      $
��Auto �6   6.   .+�5   
   ]� $��0��6   .+�5      �� $
��Left=�6   .+�5      �� $#��Добавить группу��6   $��10 10 10 10q�64   6K   �� 5      $#��Изменить группу��6C   $��10 10 10 10q�6]   ��6   �� *ChangeBGroupCommand+6t   �� 5      $!��Удалить группу��6C   $��10 10 10 10q�6\   ��6   �� *RemoveBGroupCommand+6s   5      5      �� 5    
   $��0��6   $��1��6$   $��2��64   $��3��6H   $
��Auto=�6Y   $
��Auto=�6|   .��5!      R� $��10 10 10 10q�68   ��6   �� *	BGroups+��5"      �� 5#       �� ItemsSource 6/   �� *BGroupsChildren+.R�5$      ��  �� Orientation$ 
Horizontal=�6%   .+�5%      �� $	��3 2q�6y   ��6(   �� *DisplayMember+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6y   5&      5'      .  (System.Windows.Interactivity.Interaction   	Behaviors 5)      .   (BCG_UI.View.BindableSelectedItemBehavior  5*         SelectedItem 69   �� *SelectedBGroup+$ TwoWay=�$ PropertyChanged=�5,      5.      �� 50   
   $��3��6   $��1��6   $.��(Допустимый дисбаланс:��6.   $��10 10 10 10q�6N   �� 51   
   $��3��6   $��2��6   $��10 10 10 10q�6�   ��6.   �� * SelectedBGroup.ValidDisbalance+$ TwoWay=�$ PropertyChanged=�6�   54      55      