<script src="https://cdn.quilljs.com/1.3.6/quill.js"></script>
<div id="editor"></div>
<input type="hidden" name="Description" />
<script>
    var quill = new Quill('#editor', { theme: 'snow' });
    $('form').submit(function () {
        $('input[name=Description]').val(quill.root.innerHTML);
    });
</script>
