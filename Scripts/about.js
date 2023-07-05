document.addEventListener("DOMContentLoaded", function () {
    var visualsContainer = document.getElementById("visuals");

    var colors = ["#ff0000", "#00ff00", "#0000ff", "#ffff00"];

    for (var i = 0; i < colors.length; i++) {
        var visualItem = document.createElement("div");
        visualItem.className = "visual-item";
        visualItem.style.backgroundColor = colors[i];
        visualsContainer.appendChild(visualItem);
    }
});
