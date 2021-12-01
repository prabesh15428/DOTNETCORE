﻿<script>

    $(document).ready(function(){
        $('#Upload').click(function () {

            var fileUpload = $("#files").get(0);
            var files = fileUpload.files;

            // Create  a FormData object
            var fileData = new FormData();

            // if there are multiple files , loop through each files
            for (var i = 0; i < files.length; i++) {
                fileData.append(files[i].name, files[i]);
            }

            // Adding more keys/values here if need
            fileData.append('Test', "Test Object values");

            $.ajax({
                url: '/Home/UploadFiles', //URL to upload files 
                type: "POST", //as we will be posting files and other method POST is used
                processData: false, //remember to set processData and ContentType to false, otherwise you may get an error
                contentType: false,
                data: fileData,
                success: function (result) {
                    alert(result);
                },
                error: function (err) {
                    alert(err.statusText);
                }
            });

        });
});
    </script>