   M S B A M L   `   `   `  ����@  <Lab04, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab04Lab04  5   	       Lab04.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Lab04     5   	     � Title$  Conference Manager��5   	   $	��600��6$   $	��800��61    � 
ResizeMode$ CanMinimize=�6=   .��5	      � -   5        $��myGrid��5	      .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��ConferencesDG��5
   *   $��10,10,431,206q�6      
IsReadOnly .     CanUserAddRows .     CanUserDeleteRows .  6�     5   
   -   5          Name$ 
VisitorsDG��5   +   $��374,188,10,206q�6    .   .  6�   �� 5   
   -   5        $��
FeedbackTB��5      $��Feedback��6$   $
��Left=�64   $��374,383,0,0q�6O    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��400��6�   $	��105��6�   $��16(�6�   ���	#FFE4E4E46�   �� 5   
   -   5        $��selectedVisitorL��5      $�� ��6)   $��Center=�64   $��	0,148,0,0q�6Q   $	��Top=�6d   �� 5   
   -   5        $��selectedConferenceL��5      $�� ��6,   $
��Left=�67   $��538,148,0,0q�6R   $	��Top=�6g   �� 5   
   -   5        $��AddBtnC��5      $��Add conference��6    $
��Left=�69   $��
10,401,0,0q�6T   $	��Top=�6h   $��41��6�   $	��111��6�   6�   �� 5   
   -   5         ��Name$ 
DeleteBtnC��5      $��Delete conference��6%   $
��Left=�6A   $��134,401,0,0q�6\   $	��Top=�6q   $��41��6�   $	��111��6�   {�.  6�   �� 5   
   -	   5        $ DeleteVisitorBt��5      $��Delete visitor��6*   $
��Left=�6C   $��663,506,0,0q�6^   $	��Top=�6s   $��41��6�   $	��111��6�   {�.  6�   �� 5   
   -
   5        $ AddVisitorBt��5      $��Add visitor��6'   $
��Left=�6=   $��543,506,0,0q�6X   $	��Top=�6m   $��41��6�   $	��111��6�   {�.  6�   5      5      