### List view without header and border

```xml
<UserControl.Resources>
		<Style x:Key="CoresHeaderStyle" TargetType="{x:Type GridViewColumnHeader}">
			<Setter Property="Visibility" Value="Collapsed" />
		</Style>
	</UserControl.Resources>
	<Grid Margin="0,20,0,0">
		<StackPanel>
			<TextBlock Text="Cores" FontWeight="Bold"/>
			<ListView ItemsSource="{Binding Cores}" BorderThickness="0">
				<ListView.View >
					<GridView ColumnHeaderContainerStyle="{StaticResource CoresHeaderStyle}">
						<GridViewColumn  DisplayMemberBinding="{Binding}">
							<GridViewColumnHeader Tag="Name" Content="Name"/>
						</GridViewColumn>
					</GridView>
				</ListView.View>
			</ListView>
		</StackPanel>
	</Grid>
```