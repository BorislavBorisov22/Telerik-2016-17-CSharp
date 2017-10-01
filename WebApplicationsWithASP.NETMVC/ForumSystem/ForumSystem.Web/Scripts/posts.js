const GET_ALL_POSTS_URL = '/posts/getpostsasync';

$('#btn-get-posts').on('click', () => {
    $.ajax({
        url: GET_ALL_POSTS_URL,
        method: 'GET',
        success: (responseData) => {
            console.log
            $("#posts-container").html(responseData);
        },
        error: (err) => {
            console.log(err);
        }
    })
});