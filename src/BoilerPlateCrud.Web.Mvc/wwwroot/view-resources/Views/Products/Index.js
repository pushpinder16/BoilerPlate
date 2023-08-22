(function ($) {
  var _productService = abp.services.app.productService,
    l = abp.localization.getSource('BoilerPlateCrud'),
    _$modal = $('#ProductCreateModal'),
    _$form = _$modal.find('form'),
    _$table = $('#ProductTable');

  var _$productTable = _$table.DataTable({
    paging: true,
    serverSide: true,
    ajax: function (data, callback, settings) {
      var filter = $('#ProductSearchForm').serializeFormToObject(true);
      filter.maxResultCount = data.length;
      filter.skipCount = data.start;

      abp.ui.setBusy(_$table);
      _productService.getAll(filter).done(function (result) {
        callback({
          recordsTotal: result.totalCount,
          recordsFiltered: result.totalCount,
          data: result.items
        });
      }).always(function () {
        abp.ui.clearBusy(_$table);
      });
    },
    buttons: [
      {
        name: 'refresh',
        text: '<i class="fas fa-redo-alt"></i>',
        action: () => _$productTable.draw(false)
      }
    ],
    responsive: {
      details: {
        type: 'column'
      }
    },
    columnDefs: [
      {
        targets: 0,
        className: 'control',
        defaultContent: '',
      },
      {
        targets: 1,
        data: 'id',
        sortable: false
      },
      {
        targets: 2,
        data: 'productId',
        sortable: false
      },
      {
        targets: 3,
        data: 'name',
        sortable: false
      },
      {
        targets: 4,
        data: 'quantity',
        sortable: false
      },

      {
        targets: 5,
        data: null,
        sortable: false,
        autoWidth: false,
        defaultContent: '',
        render: (data, type, row, meta) => {
          return [
            `   <button type="button" class="btn btn-sm bg-secondary edit-product" data-product-id="${row.id}" data-toggle="modal" data-target="#ProductEditModal">`,
            `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
            '   </button>',
            `   <button type="button" class="btn btn-sm bg-danger delete-product" data-product-id="${row.id}" data-product-name="${row.name}">`,
            `       <i class="fas fa-trash"></i> ${l('Delete')}`,
            '   </button>'
          ].join('');
        }
      }
    ]
  });

  _$form.validate({
    rules: {
      Password: "required",
      ConfirmPassword: {
        equalTo: "#Password"
      }
    }
  });

  _$form.find('.save-button').on('click', (e) => {
    e.preventDefault();

    if (!_$form.valid()) {
      return;
    }

    var product = _$form.serializeFormToObject();
    product.roleNames = [];
    var _$roleCheckboxes = _$form[0].querySelectorAll("input[name='role']:checked");
    if (_$roleCheckboxes) {
      for (var roleIndex = 0; roleIndex < _$roleCheckboxes.length; roleIndex++) {
        var _$roleCheckbox = $(_$roleCheckboxes[roleIndex]);
        product.roleNames.push(_$roleCheckbox.val());
      }
    }

    abp.ui.setBusy(_$modal);
    alert(JSON.stringify(product));
    _productService.create(product).done(function () {
      _$modal.modal('hide');
      _$form[0].reset();
      location.reload();
      abp.notify.info(l('SavedSuccessfully'));
      _$productsTable.ajax.reload();
    }).always(function () {
      abp.ui.clearBusy(_$modal);
    });
  });

  $(document).on('click', '.delete-product', function () {
    var id = $(this).attr("data-product-id");
    var name = $(this).attr('data-product-name');

    deleteProduct(id, name);
  });

  function deleteProduct(id, name) {
    abp.message.confirm(
      abp.utils.formatString(
        l('AreYouSureWantToDelete'),
        name),
      null,
      (isConfirmed) => {
        if (isConfirmed) {
          _productService.delete({
            id: id
          }).done(() => {
            abp.notify.info(l('SuccessfullyDeleted'));
            _$productTable.ajax.reload();
          });
        }
      }
    );
  }
 
  $(document).on('click', '.edit-product', function (e) {
    var Id = $(this).attr("data-product-id");

    e.preventDefault();
    abp.ajax({
      url: abp.appPath + 'Product/EditModal?id=' + Id,
      type: 'POST',
      dataType: 'html',
      success: function (content) {
        $('#ProductEditModal div.modal-content').html(content);
      },
      error: function (e) { }
    });
  });

  $(document).on('click', 'a[data-target="#ProductListViewModel"]', (e) => {
    $('.nav-tabs a[href="#product-details"]').tab('show')
  });

  abp.event.on('product.edited', (data) => {
    _$productTable.ajax.reload();
  });

  _$modal.on('shown.bs.modal', () => {
    _$modal.find('input:not([type=hidden]):first').focus();
  }).on('hidden.bs.modal', () => {
    _$form.clearForm();
  });

  $('.btn-search').on('click', (e) => {
    _$productTable.ajax.reload();
  });

  $('.txt-search').on('keypress', (e) => {
    if (e.which == 13) {
      _$productTable.ajax.reload();
      return false;
    }
  });
})(jQuery);
