
//GridViewId      表单ID号；
//NormalColor     偶数行的颜色
//AlterColor 奇数行的颜色
//HoverColor 鼠标移上的颜色

//SelectColor     选中的效果

function GridViewColor(gridViewId, normalColor, alterColor, hoverColor, selectColor) {

    var temp = document.getElementById(gridViewId);

    if (temp.length == 0)
        return;

    var allRows = document.getElementById(gridViewId).getElementsByTagName("tr");

    for (var i = 0; i < allRows.length; i++) {
        allRows[i].style.background = i % 2 == 0 ? normalColor : alterColor;
        if (hoverColor != "") {

            allRows[i].onmouseover =
                function() {
                    if (!this.selected)
                        this.style.background = hoverColor;
                };

            if (i % 2 == 0) {

                allRows[i].onmouseout = function() {
                    if (!this.selected)
                        this.style.background = normalColor;
                };

            } else {

                allRows[i].onmouseout
                    =
                    function() {

                        if (!this
                            .selected)

                            this
                                .style.background
                                = alterColor;
                    };

            }

        }


        if (selectColor != "") {

            allRows[i].onclick = function() {

                var nodes = this.parentNode.childNodes;

                for (
                    var i = 0; i < nodes.length; i++) {

                    if (i % 2 == 0) {

                        nodes[i].style.backgroundColor = normalColor;

                    } else
                        nodes[i].style.backgroundColor = alterColor;

                    nodes[i].selected = false;

                }

                this.style.background = selectColor;

                this.selected = !this.selected;

            };

        }

    }

}

