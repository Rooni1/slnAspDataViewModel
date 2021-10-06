var Hello = React.createClass({
    rendder: function () {
        return (
            <div> Hello its first React App</div>
        );
    }
});
React.rendder(<Hello />, document.getElementById("reactDiv"));