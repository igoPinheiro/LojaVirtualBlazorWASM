function MakeUpdateQuantityVisibleButton(id, visible) {
    const updateQtdBtn = document.querySelector("button[data-itemId='" + id + "']");
    if (visible == true) {
        updateQtdBtn.style.display = "inline-block";
    } else {
        updateQtdBtn.style.display = "none";
    }
}