function run() {
  new Vue({
    el: "#app",
    data: {
      users: [],
      usersService: null,
      createAlbum: "",
      createArtist: "",
      createPrice:"",
      deleteAlbum: "",
    },

    methods: {
      showDetails(user) {
        // Redirect to details page passing user data
        window.location.href = 'details.html?album=' + encodeURIComponent(user.album) + '&artist=' + encodeURIComponent(user.artist) + '&price=' + encodeURIComponent(user.price);
    },
      
      showMusic:function(){
        this.usersService = users();
      
      this.usersService.get().then((response) => { this.users = response.data });
      },
      addUser: function () {
        if (this.createAlbum.trim() !== "" && this.createArtist.trim() !== ""&&this.createPrice.trim() !== "") {
          const newUser = { album: this.createAlbum, artist: this.createArtist,price:this.createPrice };
          axios.post("http://localhost:3000/createUser", newUser)
            .then(response => {
              this.users = response.data;
              this.createAlbum = "";
              this.createArtist = "";
              this.createPrice="";
            })
            .catch(error => {
              console.error("Error adding user:", error);
            });
        } else {
          alert("Please enter valid Album name!");
        }
      },

      deleteUserByAlbum: function () {
        const albumToDelete = this.deleteAlbum;
        const index = this.users.findIndex(user => user.album.trim() === albumToDelete);
        if (index !== -1) {
          axios.delete(`http://localhost:3000/deleteUser?index=${index}`)
            .then(response => {
              this.users = response.data;
              alert("User deleted successfully!");
              this.deleteAlbum = "";
            })
            .catch(error => {
              console.error("Error deleting user:", error);
            });
        } else {
          alert("User not found!");
        }
      },
      updateAlbum() {
        const index = this.selectedAlbumToUpdate;
        const updatedUser = {
          index: index,
          artist: this.updatedArtist.trim(),
          price: this.updatedPrice.trim()
        };
        axios.put("http://localhost:3000/updateUser", updatedUser)
          .then(response => {
            this.users[index] = response.data;
            this.selectedAlbumToUpdate = null;
            this.updatedArtist = "";
            this.updatedPrice = "";
          })
          .catch(error => {
            console.error("Error updating user:", error);
          });
      }
    }
  });
}


document.addEventListener("DOMContentLoaded", () => {
  run();
});
