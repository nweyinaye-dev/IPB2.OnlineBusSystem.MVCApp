# Edit Bus Popup Workflow

This document explains how the "Edit Bus" popup works, from the user clicking the button to the data being saved on the server.

### 1. Data Carrier (Row Button)
Each "Edit" button in the table has `data-bs-*` attributes that store the bus information locally in the browser:

```html
<button type="button" 
        data-bs-toggle="modal" 
        data-bs-target="#editBusModal"
        data-id="@bus.Id" 
        data-no="@bus.BusNo" 
        data-name="@bus.BusName" 
        data-type="@bus.BusType" 
        data-seats="@bus.TotalSeat">
    <i class="fas fa-edit"></i>
</button>
```

### 2. Modal Partial View
The modal structure is defined in [Bus/Edit.cshtml](file:///e:/NYA_Working/.NetClass/IPB2.OnlineBusSystem.MVCApp/IPB2.OnlineBusSystem.MVCApp/Views/Bus/Edit.cshtml) as a partial view. It is included at the bottom of the [Bus/Index.cshtml](file:///e:/NYA_Working/.NetClass/IPB2.OnlineBusSystem.MVCApp/IPB2.OnlineBusSystem.MVCApp/Views/Bus/Index.cshtml) page using:

```razor
<partial name="Edit" model="new UpdateBusRequest()" />
```

### 3. Data Sync (JavaScript)
When a modal is about to open (`show.bs.modal` event), a script at the bottom of [Index.cshtml](file:///e:/NYA_Working/.NetClass/IPB2.OnlineBusSystem.MVCApp/IPB2.OnlineBusSystem.MVCApp/Views/Bus/Index.cshtml) captures the data from the clicked button and populates the modal's input fields:

```javascript
editBusModal.addEventListener('show.bs.modal', function (event) {
    const button = event.relatedTarget; // Button that triggered the modal
    const id = button.getAttribute('data-id');
    const no = button.getAttribute('data-no');
    // ... extract others
    
    // Set values into the form inputs
    editBusModal.querySelector('#editBusId').value = id;
    editBusModal.querySelector('#editBusNo').value = no;
    // ... set others
});
```

### 4. Form Submission
When the user clicks "Update Bus", the browser gathers the modified data from the modal's inputs and sends a `POST` request to the server:

*   **URL**: `/Bus/Edit`
*   **Method**: `POST`
*   **Payload**: Contains the `Id`, `BusNo`, `BusName`, `BusType`, and `TotalSeat`.

### 5. Server Processing (Controller)
In [BusController.cs](file:///e:/NYA_Working/.NetClass/IPB2.OnlineBusSystem.MVCApp/IPB2.OnlineBusSystem.MVCApp/Controllers/BusController.cs), the [Edit](file:///e:/NYA_Working/.NetClass/IPB2.OnlineBusSystem.MVCApp/IPB2.OnlineBusSystem.MVCApp/Controllers/BusController.cs#L55-L69) action handles the incoming request:

```csharp
[HttpPost]
public async Task<IActionResult> Edit(UpdateBusRequest request, string id)
{
    if (ModelState.IsValid)
    {
        var result = await _busService.UpdateAsync(request, id);
        if (result.Status == ResponseType.Success)
        {
            return RedirectToAction(nameof(Index)); // Return to list on success
        }
    }
    return RedirectToAction(nameof(Index));
}
```

The service updates the database, and the user is redirected back to the updated list.
