### Simple list view
```xml
		<ListView ItemsSource="{Binding Items}">
			<ListView.View>
				<GridView>
					<GridViewColumn  DisplayMemberBinding="{Binding Name}" Width="120">
						<GridViewColumnHeader Tag="Name" Content="Name"  />
					</GridViewColumn>
				</GridView>
			</ListView.View>
		</ListView>
```