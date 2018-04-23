@modelType System.Collections.IEnumerable
@Code
	Dim grid = Html.DevExpress().GridView(Sub(settings)
				settings.Name = "gvEditing"
				settings.KeyFieldName = "ProductID"
				settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "InlineEditingPartial"}
				settings.CommandColumn.ShowSelectCheckbox = True
				settings.CommandColumn.Visible = True

				settings.Columns.Add("ProductID")
				settings.Columns.Add("ProductName")

				settings.Columns.Add("QuantityPerUnit")
				settings.PreRender = Sub(sender, e)
					  Dim gridView As MVCxGridView = TryCast(sender, MVCxGridView)
					  If (gridView IsNot Nothing) AndAlso (ViewData("selectedRows") IsNot Nothing) Then
						  Dim selectedRows() As Integer = CType(ViewData("selectedRows"), Integer())
						  For Each key As Integer In selectedRows
							  gridView.Selection.SelectRowByKey(key)
						  Next key
					  End If
				End Sub		  
			End Sub)
End Code
@grid.Bind(Model).GetHtml()
