   M S B A M L   `   `   `  ����A  =Prac03, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Prac03Prac03  5   	       Prac03.AdminToolsWin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Prac03     5   	   -   5          � Title$  Admin tools��5   	   $	��450��6   $	��800��6*    � 
ResizeMode$ CanMinimize=�66    � WindowStyle$ 
ToolWindow=�6O    � WindowStartupLocation$ CenterScreen=�6   .��5	      � ���	#FFC9CEB6.+�5
   
   �� $��Change password��6   $
��Left=�6*   $��	45,29,0,0q�6E   $	��Top=�6X   $��24(�6p   �� 5   
   -   5        $��	OldPassTB��5      $
��Left=�6#   $��
144,75,0,0q�6>    �� TextWrapping$
 Wrap=�6R   $�� ��6f   $	��Top=�6n   $	��229��6�   $��34��6�   $��20(�6�   6�   �� 5   
   -   5         ��Name$ 	NewPassTB��5      $
��Left=�6%   $��144,130,0,0q�6@   $
 Wrap=�6U   $�� ��6i   $	��Top=�6q   $	��229��6�   $��34��6�   $��20(�6�   6�   �� 5   
   -   5        $ RepeatNewPassTB��5      $
��Left=�6+   $��144,185,0,0q�6F   $
 Wrap=�6[   $�� ��6o   $	��Top=�6w   $	��229��6�   $��34��6�   $��20(�6�   6�   �� 5   
   $��Old password:��6   $
��Left=�6(   $��	10,80,0,0q�6C   $	��Top=�6V   �� 5   
   $��New password:��6   $
��Left=�6(   $��
10,135,0,0q�6C   $	��Top=�6W   �� 5   
   $��Repeat new password:��6   $
��Left=�6/   $��
10,185,0,0q�6J   $	��Top=�6^   �� 5   
   -   5        $��ChangePassBtn��5      $��Change��6&   $
��Left=�67   $��
87,250,0,0q�6R   $	��Top=�6f   $	��114��6~   $��28��6�   {�.  6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��UsersDG��5   %      
IsReadOnly . $
��Left=�64   $	��262��6O   $��
400,16,0,0q�6\   $	��Top=�6p   $	��365��6�    �� SelectedIndex$ 0��6�   �� 5   
   -   5        $��BlockCB��5      $��
Block user��6"   $
��Left=�67   $��453,298,0,0q�6R   $	��Top=�6g   6   �� 5   
   -   5        $��CustomPassCB��5      $$��Allow creating custom password��6'   $
��Left=�6P   $��546,298,0,0q�6k   $	��Top=�6�   6�   �� 5   
   $��Add user��6   $
��Left=�6#   $��
87,298,0,0q�6>   $	��Top=�6R   $��24(�6j   �� 5   
   -	   5        $��LoginTB��5      $
��Left=�6!   $��144,359,0,0q�6<   $
 Wrap=�6Q   $�� ��6e   $	��Top=�6m   $	��229��6�   $��34��6�   $��20(�6�   6�   �� 5   
   $��New user login:��6   $
��Left=�6*   $��
28,363,0,0q�6E   $	��Top=�6Y   �� 5   
   -
   5         ��Name$ 
AddUserBtn��5      $	��Add��6%   $
��Left=�63   $��413,363,0,0q�6N   $	��Top=�6c   $	��114��6{   $��28��6�   {�.  6�   5      5      