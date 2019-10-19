function ExcluirAlbum(AlbumId) {
    $(".modal").modal();
    $(".btnConfirmarExclusao").on('click', function () {
        $.ajax({
            url: '/Album/Excluir',
            type: 'POST',
            data: { AlbumId: AlbumId },
            success: function () {
                location.reload();
                $(".modal").modal('close');
            }
        })
    });
}