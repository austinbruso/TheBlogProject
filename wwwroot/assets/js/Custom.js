let index = 0;

function AddTag() {
    //Get a referece to the TagEntry input element
    var tagEntry = document.getElementById("TagEntry");


    //Lets use the new search function to help detect an error state
    let searchResult = search(tagEntry.value);
    if (searchResult != null) {
        //Trigger my sweet alert for whatever condition is contained in the searchResult var

        swalWithDarkButton.fire({
            html: `<span class='font-weight-bolder>${searchResult.toUpperCase()}</span>`  
        });
    }
    else {
        let newOption = new Option(tagEntry.value, TagEntry.value);
        document.getElementById("TagList").options[index++] = newOption;
    }
 
    // Clear out the TagEntry control 
    tagEntry.value = "";
    return true;
}

function DeleteTag() {
    let tagCount = 1;
    while (tagCount > 0) {
        let tagList = document.getElementById("TagList");
        let selectedIndex = tagList.selectedIndex;
        if (selectedIndex >= 0) {
            tagList.options[selectedIndex] = null;
            --tagCount;
        }
        else
            tagCount = 0;
        index--;
    }
}

$("form").on("submit", function () {
    $("#TagList option").prop("selected", "selected");
})

//Look for the TagValues variable to see if it has data
if (tagValue != '') {
    let tagArray = tagValues.split(",");
    for (let loop = 0; loop < tagArray.length; loop++) {
        //Load up or replace the options that we have
        ReplaceTag(tagArray[loop], loop);
        index++;
    }
}

function ReplaceTag(tag, index) {
    let newOption = new Option(tag, tag);
    document.getElementById("TagList").options[index] = newOption;
}

//The Search function will detect either an empty or duplicate Tag
//and return an error string if an error is detected
function search(str) {
    if (str == "") {
        return 'Empty tags are not permitted'
    }

    var tagsEl = document.getElementById('TagList');
    if (tagEl) {
        let options = tagsEl.options;
        for (let index = 0; index < options.length; index++) {
            if (options[index].value == str)
                return `The Tag #${str} was detected as a duplicate and is not permitted`
        }

    }


}

const swalWithDarkButton = Swal.mixin({
    customClass: {
        confirmButton: 'btn btn-danger btn-sm btn-block btn-outline-dark'
    },
    imageUrl: '/images/oops.jfif',
    timer: 3000,
    buttonsStyling: false
});