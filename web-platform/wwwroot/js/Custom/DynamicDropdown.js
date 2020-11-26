function dynamicdropdownx(listindex) {
    const nameSelect = document.getElementById("name")
    while (nameSelect.options.length > 0) {
        nameSelect.remove(0);
    }
    switch (listindex) {
        case "cms":
            nameSelect.options[0] = new Option("Select status", "");
            nameSelect.options[0].disabled = true;
            nameSelect.options[1] = new Option("Umbraco UNO", "Umbraco UNO");
            nameSelect.options[2] = new Option("Umbraco Cloud", "Umbraco Cloud");
            nameSelect.options[3] = new Option("Umbraco Hearthbreak", "Umbraco Hearthbreak");
            nameSelect.options[4] = new Option("Umbraco CMS", "Umbraco CMS");
            break;
        case "package":
            nameSelect.options[0] = new Option("Select status");
            nameSelect.options[0].disabled = true;
            nameSelect.options[1] = new Option("Forms", "Forms");
            nameSelect.options[2] = new Option("uSync", "uSync");
            break;
    }
    return true;
}